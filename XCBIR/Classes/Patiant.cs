using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents patiant record in the database 
    /// </summary>
    public class Patiant
    {
        /// <summary>
        /// Patiant ID
        /// </summary>
        private string id;
        /// <summary>
        /// Patiant name
        /// </summary>
        private string name;
        /// <summary>
        /// Patiant age
        /// </summary>
        private string age;
        /// <summary>
        /// Patiant information
        /// </summary>
        private string info;

        /// <summary>
        /// Creates new instance of Patiant Class
        /// </summary>
        /// <param name="ID">The ID of this patiant</param>
        /// <param name="Name">The name of this patiant</param>
        /// <param name="Age">The age of this patiant</param>
        /// <param name="Information">The information of this patiant</param>
        public Patiant(string ID, string Name, string Age, string Information)
        {
            this.id = ID;
            this.name = (Name == null) ? "" : Name;
            this.age = (Age == null) ? "0" : Age;
            this.info = (Information == null) ? "" : Information;
        }

        /// <summary>
        /// Gets or sets patiant ID
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
        /// Gets or sets patiant name
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
        /// Gets or sets patiant age
        /// </summary>
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /// <summary>
        /// Gets or sets patiant information
        /// </summary>
        public string Information
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        /// <summary>
        /// Inserts new patiant into the database
        /// </summary>
        /// <param name="DBC">The controller through which patiant insertion will be done</param>
        public bool InsertPatiant(databaseController DBC)
        {
            string sqlstr;
            try
            {
                sqlstr = "INSERT INTO Patiant VALUES ( " +
                    this.id + " , '" + this.name + "' , " + this.age + " , '" + this.info + "' );";

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
        /// Updates an existing patiant
        /// </summary>
        /// <param name="DBC">The controller through which patiant update will be done</param>
        public bool UpdatePatiant(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "UPDATE Patiant SET ";
                sqlstr = sqlstr + "Name ='" + this.name + "',";
                sqlstr = sqlstr + "Age = " + this.age + " ,";
                sqlstr = sqlstr + "Info = '" + this.info + "' ";
                sqlstr = sqlstr + "WHERE PID =" + this.id + " ;";

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
        /// Deletes an existing patiant from the database
        /// </summary>
        /// <param name="DBC">The controller through which patiant deletion will be done</param>
        public bool DeletePatiant(databaseController DBC)
        {
            string sqlstr;
            try
            {
                if (DBC.IsConnected)
                {
                    sqlstr = "DELETE FROM Patiant WHERE PID= " + this.id + " ;";
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
