using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Sven_Bobrowski.DE.Settings
{
    [Serializable]
    public class ApplicationSettings
    {
        public string LastDBFileCreated { get; set; }
        
        public string LastDBFolder { get; set; }

        public string CurrentDBPath { get; set; }

        [XmlIgnoreAttribute]
        public static ApplicationSettings Singleton { get; private set; }

        public static string DefaultSaveFilePath()
        {
            string tFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sven-Bobrowski.DE.MP");
            if (!Directory.Exists(tFolder))
                Directory.CreateDirectory(tFolder);

            return Path.Combine(tFolder, "settings.xml");
        }

        public ApplicationSettings()
        {
            LastDBFileCreated = "";
            LastDBFolder = "";
        }

        public static ApplicationSettings Load(string pConfigFilePath)
        {

            ApplicationSettings tSettings = new ApplicationSettings();
            StreamReader tReader = null;

            if (File.Exists(pConfigFilePath))
            {
                try
                {
                    XmlSerializer tSerializer = new XmlSerializer(typeof(ApplicationSettings));
                    tReader = new StreamReader(pConfigFilePath);
                    tSettings = (ApplicationSettings)tSerializer.Deserialize(tReader);
                }
                catch
                {
                    throw new Exception(pConfigFilePath + " - could not be deserialized!");
                }
                finally
                {
                    if (null != tReader)
                    {
                        tReader.Close();
                    }
                }

            }
            else
            {
                tSettings.Save(pConfigFilePath);
            }

            Singleton = tSettings;
            return tSettings;
        }

        public void Save(string pConfigFilePath = @"c:\usersettings.xml")
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
                StreamWriter writer = new StreamWriter(pConfigFilePath);

                serializer.Serialize(writer, this);

                writer.Flush();
                writer.Close();
            }
            catch
            {
                throw new Exception(pConfigFilePath + " - could not be serialized!");
            }
        }
    }
}
