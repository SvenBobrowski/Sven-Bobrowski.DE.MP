using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

using Sven_Bobrowski.DE.Data.Properties;
using Sven_Bobrowski.DE.Settings;
using Sven_Bobrowski.DE.Integration;

namespace Sven_Bobrowski.DE.Data
{
    public class Database
    {
        public bool CreateDatabase()
        {
            string tFilename = "";
            string tLastFolder = "";

            // create a new blank database for our project
            SaveFileDialog tDlg = new SaveFileDialog();

            tDlg.Filter = Resources.DB_Save_Dlg_Filter;
            tDlg.Title = Resources.DB_Save_Dlg_Title;
            tDlg.DefaultExt = ".db";

            if (tDlg.ShowDialog() == DialogResult.OK)
            {
                if (tDlg.FileName != "")
                {
                    // get the filename
                    tFilename = tDlg.FileName;
                    tLastFolder = Path.GetDirectoryName(tFilename);
                }
            }

            // FF store as infos
            ApplicationSettings tSettings = new ApplicationSettings();
            tSettings.LastDBFileCreated = tFilename;
            tSettings.LastDBFolder = tLastFolder;
            tSettings.Save(ApplicationSettings.DefaultSaveFilePath());

            // create database now
            return NewDatabase(tFilename);
        }

        public bool NewDatabase(string pDatabasePath)
        {
            try
            {
                // delete current (user was asked)
                if (File.Exists(pDatabasePath))
                    File.Delete(pDatabasePath);

                // create new
                SQLiteConnection.CreateFile(pDatabasePath);

                // connect and create tables
                using (SQLiteConnection tConnection = new SQLiteConnection(String.Format("Data Source={0};Version=3;", pDatabasePath)))
                {
                    tConnection.Open();
                    
                    // "external" table
                    string tSQLExternalTable = "CREATE TABLE [external] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [External_Type] WORD, [External_Key] CHAR(30), [External_StringValue] CHAR(255), " +
                        "[External_ImageValue] GRAPHIC);";
                    using (SQLiteCommand tSqlExternalTable = new SQLiteCommand(tSQLExternalTable, tConnection))
                    {
                        tSqlExternalTable.ExecuteNonQuery();
                    }

                    // "decoder" table
                    string tSQLDecoderTable = "CREATE TABLE [decoder] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [Decoder_Type] WORD, [DecoderProtocol] WORD, [Decoder_Label] CHAR(5), " +
                        "[Decoder_Name] CHAR(255), [Decoder_Manufacturer] CHAR(255), [Decoder_ManualUrl] TEXT, [Decoder_Connections] INT, [Decoder_Connections_Used] INT, [Decoder_Notes] TEXT);";
                    using (SQLiteCommand tSqlDecoderTable = new SQLiteCommand(tSQLDecoderTable, tConnection))
                    {
                        tSqlDecoderTable.ExecuteNonQuery();
                    }

                    // "main" table
                    string tSQLMainTable = "CREATE TABLE [main] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [Decoder_ID] INT, [Point] INT, [DCC_Adress_1] INT, [DCC_Adress_2] INT, [DCC_Adress_3] INT," +
                        "[DCC_Adress_4] INT, [State] WORD, [External_ID_1] INT, [External_ID_2] INT, [External_ID_3] INT, [External_ID_4] INT, " +
                        "[Notes] TEXT);";
                    using (SQLiteCommand tSqlMainTable = new SQLiteCommand(tSQLMainTable, tConnection))
                    {
                        tSqlMainTable.ExecuteNonQuery();
                    }

                    tConnection.Close();
                }
            }
            catch (Exception e)
            {
                string tMsg =
                    String.Format(Resources.DB_Create_Failed_1 + Environment.NewLine + Resources.DB_Create_Failed_2, pDatabasePath, e.Message);
                MessageBox.Show(tMsg, Resources.DB_Create_Failed_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            
            return true;
        }

        public void ToItemList(string pDBPath, ref Sven_Bobrowski.DE.Integration.Items pItems)
        {
            if (pItems == null)
                pItems = new Items();

            // FF
        }

        private bool DataItemExists(SQLiteConnection pConnection, int pId)
        {
            try
            {
                using (var tCommand = new SQLiteCommand(pConnection))
                {
                    tCommand.CommandText = String.Format("SELECT * FROM main WHERE (ID = {0});", pId);
                    using (SQLiteDataReader tReader = tCommand.ExecuteReader())
                    {
                        if (!tReader.Read())
                        {
                            tReader.Close();

                            return false;
                        }
                        else
                        {
                            tReader.Close();

                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private int InsertExternalItem(SQLiteConnection pConnection, IExternalItem pExternalItem)
        {
            try
            {
                using (var tCommand = new SQLiteCommand(pConnection))
                {
                    string tSQLCmdText = "INSERT INTO external (External_Type, External_Key, External_StringValue) VALUES (" + Convert.ToString((int)pExternalItem.Type) + ", '" + pExternalItem.Key +
                        "', '" + pExternalItem.Value + "');";
                    tCommand.CommandText = tSQLCmdText;
                    tCommand.ExecuteNonQuery();

                    tCommand.CommandText = "SELECT last_insert_rowid();";
                    using (SQLiteDataReader tReader = tCommand.ExecuteReader())
                    {
                        tReader.Read();
                        int tId = Convert.ToInt32(tReader[0]);

                        pExternalItem.ID = tId;
                        return tId;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Internal error (something goes wrong with an sql statement, source: InsertExternalItem): \"" + e.Message + "\".");
                return -1;
            }
        }

        private int InsertDataItem(SQLiteConnection pConnection, Sven_Bobrowski.DE.Integration.DataItem pItem)
        {
            try
            {
                using (var tCommand = new SQLiteCommand(pConnection))
                {
                    // we need to insert the externals now
                    int tDeviceId = InsertExternalItem(pConnection, pItem.Device);
                    int tSegmentId = InsertExternalItem(pConnection, pItem.Segment);
                    int tLabelId = InsertExternalItem(pConnection, pItem.Label);
                    int tImgId = InsertExternalItem(pConnection, pItem.Image);

                    string tSQLCmdText = "INSERT INTO main (" +
                        "Decoder_ID, " +
                        "Point, " +
                        "DCC_Adress_1, " +
                        "DCC_Adress_2, " +
                        "DCC_Adress_3, " +
                        "DCC_Adress_4, " +
                        "State, " +
                        "External_ID_1, " +
                        "External_ID_2, " +
                        "External_ID_3, " +
                        "External_ID_4, " +
                        "Notes) VALUES (" +
                        Convert.ToString(pItem.DecoderId) + ", " +
                        Convert.ToString(pItem.Point) + ", " +
                        Convert.ToString(pItem.DCCAdress1) + ", " +
                        Convert.ToString(pItem.DCCAdress2) + ", " +
                        Convert.ToString(pItem.DCCAdress3) + ", " +
                        Convert.ToString(pItem.DCCAdress4) + ", " +
                        Convert.ToString((int)pItem.State) + ", " +
                        Convert.ToString(tDeviceId) + ", " +
                        Convert.ToString(tSegmentId) + ", " +
                        Convert.ToString(tLabelId) + ", " +
                        Convert.ToString(tImgId) + ", " +
                        "'" + "" + "'" +
                        ");";
                    tCommand.CommandText = tSQLCmdText;
                    tCommand.ExecuteNonQuery();

                    tCommand.CommandText = "SELECT last_insert_rowid();";
                    using (SQLiteDataReader tReader = tCommand.ExecuteReader())
                    {
                        tReader.Read();
                        int tId = Convert.ToInt32(tReader[0]);

                        pItem.ID = tId;
                    }

                    return pItem.ID;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Internal error (something goes wrong with an sql statement, source: InsertDataItem): \"" + e.Message + "\".");
                return -1;
            }
        }

        private void UpdateDataItem(SQLiteConnection pConnection, Sven_Bobrowski.DE.Integration.DataItem pItem)
        {

        }

        public void FromItemList(string pDBPath, Sven_Bobrowski.DE.Integration.Items pItems)
        {
            if (null == pItems)
                return;

            try
            {
                // connect and create tables
                using (SQLiteConnection tConnection = new SQLiteConnection(String.Format("Data Source={0};Version=3;", pDBPath)))
                {
                    tConnection.Open();

                    // loop items
                    foreach (int tId in pItems.DataItems.Keys)
                    {
                        Sven_Bobrowski.DE.Integration.DataItem tItem;
                        if (pItems.TryGetItem(tId, out tItem))
                        {
                            // check if dataset allready exists, so update it, else add it
                            if (DataItemExists(tConnection, tId))
                            {
                                UpdateDataItem(tConnection, tItem);
                            }
                            else
                            {
                                InsertDataItem(tConnection, tItem);
                            }
                        }
                    }
                                        
                    tConnection.Close();
                }
            }
            catch (Exception e)
            {
                string tMsg =
                    String.Format(Resources.DB_Update_Failed_1 + Environment.NewLine + Resources.DB_Update_Failed_2, pDBPath, e.Message);
                MessageBox.Show(tMsg, Resources.DB_Update_Failed_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
