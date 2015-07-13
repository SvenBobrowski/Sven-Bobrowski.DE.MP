using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Sven_Bobrowski.DE.MP.Properties;
using Sven_Bobrowski.DE.Data;
using Sven_Bobrowski.DE.Settings;
using Sven_Bobrowski.DE.Integration;

namespace Sven_Bobrowski.DE.MP
{
    public partial class FormMain : Form
    {
        private Database FDB;
        private Sven_Bobrowski.DE.Integration.Items FItems;

        public FormMain()
        {
            InitializeComponent();

            FDB = new Database();
            FItems = new Items();

            ApplicationSettings.Load(ApplicationSettings.DefaultSaveFilePath());
        }

        private void ReloadData(string pDBPath)
        {
            FDB.ToItemList(pDBPath, ref FItems);
        }

        private void datenbankErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create database for internal data
            Database tDB = new Database();
            if (tDB.CreateDatabase())
            {
                // ask to assign
                if (MessageBox.Show(Resources.DB_AskToAssign_Text, Resources.DB_AskToAssign_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // set it
                    ApplicationSettings.Singleton.CurrentDBPath = ApplicationSettings.Singleton.LastDBFileCreated;
                    ApplicationSettings.Singleton.Save(ApplicationSettings.DefaultSaveFilePath());
                    // reload data
                    ReloadData(ApplicationSettings.Singleton.CurrentDBPath);
                }
            };
        }

        private void datenbankFestlegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open dialog
            OpenFileDialog tDlg = new OpenFileDialog();

            tDlg.Filter = Resources.DB_OpenDBToAssign_Filter;
            tDlg.Title = Resources.DB_OpenDBToAssign_Caption;

            if (tDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tFilename = tDlg.FileName;
                if (File.Exists(tFilename))
                {
                    ApplicationSettings.Singleton.CurrentDBPath = tFilename;
                    ApplicationSettings.Singleton.Save(ApplicationSettings.DefaultSaveFilePath());
                    // reload data
                    ReloadData(ApplicationSettings.Singleton.CurrentDBPath);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(ApplicationSettings.Singleton.CurrentDBPath))
            {
                ReloadData(ApplicationSettings.Singleton.CurrentDBPath);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // new item
            DataItem tItem = new DataItem();
            // dialog
            FormItem tDlg = new FormItem(ItemFormState.New);
            // set infos
            tDlg.Item = tItem;
            // show modal
            if (tDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // add to list
                tItem = tDlg.Item;
                FItems.AddOrSetItem(tItem);
                // synch entries to database
                if (File.Exists(ApplicationSettings.Singleton.CurrentDBPath))
                {
                    FDB.FromItemList(ApplicationSettings.Singleton.CurrentDBPath, FItems);
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // synch entries to database
            if (File.Exists(ApplicationSettings.Singleton.CurrentDBPath))
            {
                FDB.FromItemList(ApplicationSettings.Singleton.CurrentDBPath, FItems);
            }
        }
    }
}
