using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents series category in the database
    /// </summary>
    public class category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        private string id;
        /// <summary>
        /// Category name
        /// </summary>
        private string name;
        /// <summary>
        /// The parent ID of this category
        /// </summary>
        private string parent;

        /// <summary>
        /// Creates new instance of category class
        /// </summary>
        /// <param name="ID">The ID of this instance</param>
        /// <param name="Name">The name of this instance</param>
        /// <param name="Parent">The parent ID of this instance</param>
        public category(string ID, string Name, string Parent)
        {
            this.id = ID;
            this.name = Name;
            this.parent = Parent;
        }

        /// <summary>
        /// Gets or sets category ID
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
        /// Gets or sets category name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent ID of this category
        /// </summary>
        public string Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Inserts an image category
        /// </summary>
        /// <param name="DBC">The controller through which the insertion will be done</param>
        public bool InsertCategory(XCBIR.Classes.databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                if (this.parent == null)
                {
                    sqlstr = "INSERT INTO Category VALUES ( " +
                        this.id + " , '" + this.name + "' , null );";
                }
                else
                {
                    sqlstr = "INSERT INTO Category VALUES ( " +
                        this.id + " , '" + this.name + "' , " + this.parent + " );";
                }
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
        /// Deletes an image category from the database
        /// </summary>
        /// <param name="dbc">The controller through which the insertion will be done</param>
        /// <param name="DBC">The controller through which the deletion will be done</param>
        public bool DeleteCategory(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "DELETE FROM Category WHERE CatID= " + this.id + " ;";
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
