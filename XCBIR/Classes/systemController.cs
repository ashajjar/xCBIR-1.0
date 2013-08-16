using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XCBIR.Classes
{
    /// <summary>
    /// Loads the system and manages its setings
    /// </summary>
    public class systemController
    {
        /// <summary>
        /// List of connection strings the system can connect to
        /// </summary>
        private List<string> dbConnectionsList;
        /// <summary>
        /// List of system settings
        /// </summary>
        private List<string> settingsList;
        /// <summary>
        /// List of search history
        /// </summary>
        private List<string> historyList;
        /// <summary>
        /// The default connetion string
        /// </summary>
        private string defaultConnectionString;
        /// <summary>
        /// The path of the EXE application
        /// </summary>
        private string exePath;

        /// <summary>
        /// Creates new instance of systemController class
        /// </summary>
        /// <param name="EXEPath">The path of the EXE application</param>
        public systemController(string EXEPath)
        {
            this.exePath = EXEPath;
            this.dbConnectionsList = new List<string>(10);
            this.historyList = new List<string>();
            this.settingsList = new List<string>(10);
        }

        /// <summary>
        /// Gets or sets the list of connection strings the system can connect to
        /// </summary>
        public List<string> DBConnectionList
        {
            get
            {
                return dbConnectionsList;
            }
            set
            {
                dbConnectionsList = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of system settings
        /// </summary>
        public List<string> SettingsList
        {
            get
            {
                return settingsList;
            }
            set
            {
                settingsList = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of search history
        /// </summary>
        public List<string> HistoryList
        {
            get
            {
                return historyList;
            }
            set
            {
                historyList = value;
            }
        }

        /// <summary>
        /// Gets the default connection string
        /// </summary>
        public string DefaultConnectionString
        {
            get
            {
                return defaultConnectionString;
            }
        }

        /// <summary>
        /// Gets or sets the path of the EXE application
        /// </summary>
        public string EXEPath
        {
            get
            {
                if (exePath.EndsWith("\\"))
                    return exePath;
                else
                    return exePath + "\\";
            }
            set
            {
                exePath = value;
            }
        }

        /// <summary>
        /// Initializes the system and loads its components
        /// </summary>
        public int Initialize()
        {
            if (!Directory.Exists("C:\\xcbir_temp"))
            {
                Directory.CreateDirectory("C:\\xcbir_temp");
            }
            if (!Directory.Exists("C:\\XCBIR_Images"))
            {
                Directory.CreateDirectory("C:\\XCBIR_Images");
            }

            //Declarations
            FileStream fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr=new StreamReader(fs);
            fs.Close();
            sr.Close();
            string cont;
            int i;
            //System did not initialize yet
            int systemState = 0;
            try
            {
                //Load system settings from settings.lst:
                fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
                sr = new StreamReader(fs);
                cont = "";
                cont = sr.ReadLine();
                while (cont != null)
                {
                    settingsList.Add(cont);
                    cont = sr.ReadLine();
                }
                fs.Close();
                sr.Close();

                //Load DB connection strings from DBConnections.lst:
                fs = new FileStream(this.EXEPath + "DBConnections.lst", FileMode.Open, FileAccess.ReadWrite);
                sr = new StreamReader(fs);
                cont = "";
                cont = sr.ReadLine();
                while (cont != null)
                {
                    dbConnectionsList.Add(cont);
                    cont = sr.ReadLine();
                }
                fs.Close();
                sr.Close();

                //Load search history from history.lst:
                fs = new FileStream(this.EXEPath + "history.lst", FileMode.Open, FileAccess.ReadWrite);
                sr = new StreamReader(fs);
                cont = "";
                cont = sr.ReadLine();
                while (cont != null)
                {
                    historyList.Add(cont);
                    cont = sr.ReadLine();
                }
                fs.Close();
                sr.Close();
                //The system connects to the default connection string.
                for (i = 0; i < dbConnectionsList.Count; i++)
                {
                    if(dbConnectionsList[i].EndsWith("*"))
                    {
                        defaultConnectionString = dbConnectionsList[i].Trim('*');
                        break;
                    }
                }

                //The system loaded successfully
                systemState = 1;
                return systemState;
            }
            catch(Exception e)
            {
                //The system failed to load
                systemState = -1;
                fs.Close();
                sr.Close();
                return systemState;
            }
        }

        /// <summary>
        /// Adds new connection string to the system
        /// </summary>
        /// <param name="ConnectionString">The connection to add</param>
        /// <param name="Default">Indicates wether it is the default connection</param>
        public bool AddDBConnection(string ConnectionString, bool Default)
        {
            //Declarations
            FileStream fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.Close();
            fs.Close();
            
            int i;

            try
            {
                /* The connection to add is the default ;
                 find the current default connection and remove DEFAULT INDICATOR */
                if (Default)
                {
                    for (i = 0; i < dbConnectionsList.Count; i++)
                    {
                        if (dbConnectionsList[i].EndsWith("*"))
                        {
                            dbConnectionsList[i] = dbConnectionsList[i].Trim('*');
                            break;
                        }
                    }
                    dbConnectionsList.Add(ConnectionString + "*");
                }
                else
                {
                    dbConnectionsList.Add(ConnectionString);
                }
                //Write the DB connections list to the DBConnections.lst file :
                fs = new FileStream(this.EXEPath + "DBConnections.lst", FileMode.Truncate, FileAccess.Write);
                sw = new StreamWriter(fs);
                for (i = 0; i < dbConnectionsList.Count; i++)
                {
                    sw.WriteLine(dbConnectionsList[i]);
                }
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                fs.Close();
                sw.Close();
                return false;
            }
        }

        /// <summary>
        /// Clears search history of the semantic queries
        /// </summary>
        public bool ClearSearchHistory()
        {
            //Declarations
            FileStream fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
            fs.Close();
            bool historyCleared = false;

            try
            {
                fs = new FileStream(this.EXEPath + "history.lst", FileMode.Truncate, FileAccess.ReadWrite);
                historyCleared = (fs.Length == 0);
                fs.Close();
                return historyCleared;
            }
            catch(Exception e)
            {
                fs.Close();
                return false;
            }
        }

        /// <summary>
        /// Changes system settings
        /// </summary>
        public bool ChangeSettings()
        {
            //Declarations
            FileStream fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw=new StreamWriter(fs);
            fs.Close();
            sw.Close();
            int i;

            try
            {
                fs = new FileStream(this.EXEPath + "settings.lst", FileMode.Open, FileAccess.ReadWrite);
                sw = new StreamWriter(fs);
                for (i = 0; i < settingsList.Count; i++)
                {
                    sw.WriteLine(settingsList[i]);
                }
                fs.Close();
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                fs.Close();
                sw.Close();
                return false;
            }
        }

        /// <summary>
        /// Unloads system and close connections then return a value indicating wether it was done succefully or not
        /// </summary>
        public bool Exit()
        {
            try
            {
                string[] files = Directory.GetFiles(this.settingsList[1]);
                foreach (string fname in files)
                {
                    File.Delete(fname);
                }
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }
    }
}
