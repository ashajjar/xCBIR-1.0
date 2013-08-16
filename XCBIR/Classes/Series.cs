using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents series of images in the database
    /// </summary>
    public class Series
    {
        /// <summary>
        /// Image series ID
        /// </summary>
        private string id;
        /// <summary>
        /// Patiant ID for which this series belongs
        /// </summary>
        private string pid;
        /// <summary>
        /// Folder path in which this series images are put
        /// </summary>
        private string path;
        /// <summary>
        /// The categories of this series
        /// </summary>
        private List<category> catList;
        /// <summary>
        /// Notes about this series
        /// </summary>
        private string notes;

        /// <summary>
        /// Creates new instance of Series class
        /// </summary>
        /// <param name="ID">The ID of this instance</param>
        /// <param name="PID">The patiant ID of this instance</param>
        /// <param name="Path">The folder path in which this instance images images are put</param>
        /// <param name="Notes">Notes about this instance</param>
        /// <param name="CatList">The categories of this series</param>
        public Series(string ID, string PID, string Path, string Notes, List<category> CatList)
        {
            this.id = ID;
            this.pid = PID;
            this.path = Path;
            this.notes = Notes;
            this.catList = CatList;
            if (catList == null)
                catList = new List<category>();
        }

        /// <summary>
        /// Gets or sets image series ID
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets patiant ID for which this series belongs
        /// </summary>
        public string PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        /// <summary>
        /// Gets or sets folder path in which this series images are put
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        /// <summary>
        /// Gets or sets the categories of this series
        /// </summary>
        public List<category> CatList
        {
            get
            {
                return catList;
            }
            set
            {
                catList = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes about this series
        /// </summary>
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        /// <summary>
        /// Inserts new series to the system
        /// </summary>
        /// <param name="DBC">The controller through which series insertion will be done</param>
        public bool InsertSeries(databaseController DBC)
        {
            string sqlstr;
            try
            {
                sqlstr = "INSERT INTO Series VALUES ( " +
                    this.id + " , " + this.pid + " , '" + this.Path + "' );";
                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    if (DBC.ExecuteNonQuery() > 0)
                    {
                        if (InsertCats(DBC))
                        {
                            if (InsertNotes(DBC))
                            {
                                return true;
                            }
                            else
                            {
                                throw new Exception("Failed to insert the note of series !");
                            }
                        }
                        else
                        {
                            throw new Exception("Failed to insert the categories of series !");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to insert the series !");
                    }
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates an existing series
        /// </summary>
        /// <param name="DBC">The controller through which series update will be done</param>
        public bool UpdateSeries(databaseController DBC)
        {
            string sqlstr;
            try
            {
                sqlstr = "UPDATE Series SET ";
                sqlstr = sqlstr + "PID = " + this.pid + " ,";
                sqlstr = sqlstr + "FolderPath = '" + this.path + "' ";
                sqlstr = sqlstr + "WHERE SID =" + this.id + " ;";

                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    if (DBC.ExecuteNonQuery() > 0)
                    {
                        DBC.CommandText = "DELETE FROM Series_Notes WHERE SID = " + this.id + " ;";
                        DBC.ExecuteNonQuery();
                        if (InsertNotes(DBC))
                        {
                            DBC.CommandText = "DELETE FROM Series_Cats WHERE SID = " + this.id + " ;";
                            DBC.ExecuteNonQuery();
                            if (InsertCats(DBC))
                            {
                                return true;
                            }
                            else
                            {
                                throw new Exception("Failed to modify categories of series !");
                            }
                        }
                        else
                        {
                            throw new Exception("Failed to modify notes of series !");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to modify series !");
                    }
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes an existing series
        /// </summary>
        /// <param name="DBC">The controller through which series deletion will be done</param>
        public bool DeleteSeries(databaseController DBC)
        {
            string sqlstr;
            try
            {
                if (DeleteCats(DBC))
                {
                    if (DeleteNotes(DBC))
                    {
                        if (DBC.IsConnected)
                        {
                            sqlstr = "DELETE FROM Series WHERE SID = " + this.id + " ;";
                            DBC.CommandText = sqlstr;
                            if (DBC.ExecuteNonQuery() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                throw new Exception("Failed to delete the series !");
                            }
                        }
                        else
                        {
                            throw new Exception("The database is not connected!");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to delete the notes of series !");
                    }
                }
                else
                {
                    throw new Exception("Failed to delete the categories of series !");
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the notes of this series
        /// </summary>
        /// <param name="DBC">The controller through which notes insertion will be done</param>
        private bool InsertNotes(databaseController DBC)
        {
            string sqlstr = "";
            if (this.notes == "")
                return true;
            try
            {
                sqlstr = "INSERT INTO Series_Notes VALUES ( " + this.id;
                sqlstr += " , '" + this.notes;
                sqlstr += "' );";

                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    return (DBC.ExecuteNonQuery() > 0);
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the notes related to this series
        /// </summary>
        /// <param name="DBC">The controller through which notes deletion will be done</param>
        private bool DeleteNotes(databaseController DBC)
        {
            string sqlstr;
            if (this.notes == "")
                return true;
            try
            {
                sqlstr = "DELETE FROM Series_Notes WHERE SID = " + this.id + " ;";
                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    return (DBC.ExecuteNonQuery() > 0);
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Inserts the categories of this series
        /// </summary>
        /// <param name="DBC">The controller through which categories insertion will be done</param>
        private bool InsertCats(databaseController DBC)
        {
            string sqlstr = "";
            if (catList.Count < 1)
                return true;
            int inserted_cats = 0;
            try
            {
                if (DBC.IsConnected)
                {
                    foreach (category c in catList)
                    {
                        sqlstr = "INSERT INTO Series_Cats VALUES ( " + this.id;
                        sqlstr += " , " + c.ID;
                        sqlstr += " );";
                        DBC.CommandText = sqlstr;
                        if (DBC.ExecuteNonQuery() > 0)
                        {
                            inserted_cats++;
                        }
                    }
                    return (inserted_cats == catList.Count);
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the categories of the series
        /// </summary>
        /// <param name="DBC">The controller through which categories deletion will be done</param>
        private bool DeleteCats(databaseController DBC)
        {
            string sqlstr;
            if (catList.Count < 1)
                return true;
            try
            {
                sqlstr = "DELETE FROM Series_Cats WHERE (SID = " + this.id + " ) ;";

                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    return (DBC.ExecuteNonQuery() > 0);
                }
                else
                {
                    throw new Exception("The database is not connected!");
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
