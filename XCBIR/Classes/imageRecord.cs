using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents image record in the database
    /// </summary>
    public class imageRecord
    {
        /// <summary>
        /// Image ID for this record
        /// </summary>
        private string id;
        /// <summary>
        /// Image info for this record
        /// </summary>
        private string[] imageInfo;
        /// <summary>
        /// File name of the image of this record
        /// </summary>
        private string fileName;
        /// <summary>
        /// Contains the features of this image
        /// </summary>
        private List<Feature> featureVector;

        /// <summary>
        /// Creates new instance of imageRecord class
        /// </summary>
        /// <param name="ID">The ID of this instance</param>
        /// <param name="ImageInfo">The image info of this instance</param>
        /// <param name="FileName">The image file name of this instance with out the path</param>
        /// <param name="FV">The feature vector of this instance</param>
        public imageRecord(string ID,
                            string[] ImageInfo,
                            string FileName,List<Feature> FV)
        {
            this.id = ID;
            this.imageInfo = ImageInfo;
            this.fileName = FileName;
            this.featureVector = FV;
        }

        /// <summary>
        /// Gets or sets image ID for this record
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
        /// Gets or sets image info for this record
        /// </summary>
        public string[] ImageInfo
        {
            get
            {
                return imageInfo;
            }
            set
            {
                imageInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets path to the image of this record
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the features of this image
        /// </summary>
        public List<Feature> FeatureVector
        {
            get
            {
                return featureVector;
            }
            set
            {
                featureVector = value;
            }
        }

        /// <summary>
        /// Inserts an image into the database
        /// </summary>
        /// <param name="DBC">The controller through which the insertion will be done</param>
        public bool InsertImage(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "INSERT INTO Image VALUES ( " +
                    this.id + " , '" + this.fileName + "' , " + this.imageInfo[0]
                    + " , '" + this.imageInfo[1] + "' );";
                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    if (DBC.ExecuteNonQuery() > 0)
                    {
                        if (InsertImageFeatures(DBC))
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Failed to insert the features of image !");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to insert the image !");
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
        /// Modifies an image in the database
        /// </summary>
        /// <param name="DBC">The controller through which the modification will be done</param>
        public bool ModifyImage(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "UPDATE Image SET ";
                sqlstr = sqlstr + "FileName ='" + this.fileName + "',";
                sqlstr = sqlstr + "Size = " + this.imageInfo[0] + " ,";
                sqlstr = sqlstr + "Dimensions = '" + this.imageInfo[1] + "' ";
                sqlstr = sqlstr + "WHERE ImageID =" + this.id + " ;";

                if (DBC.IsConnected)
                {
                    DBC.CommandText = sqlstr;
                    if (DBC.ExecuteNonQuery() > 0)
                    {
                        if (UpdateImageFeatures(DBC))
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Failed to modify the image !");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to modify the image !");
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
        /// Deletes an image from the database.
        /// </summary>
        /// <param name="DBC">The controller through which the deletion will be done</param>
        public bool DeleteImage(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                if (DeleteImageFeatures(DBC))
                {
                    if (DBC.IsConnected)
                    {
                        sqlstr = "DELETE FROM Image WHERE ImageID= " + this.id + " ;";
                        DBC.CommandText = sqlstr;
                        if (DBC.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Failed to delete the image !");
                        }
                    }
                    else
                    {
                        throw new Exception("The database is not connected!");
                    }
                }
                else
                {
                    throw new Exception("Failed to delete the image !");
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Views an image from results
        /// </summary>
        public Bitmap ViewImage()
        {
            Bitmap bmp = new Bitmap(this.FileName);
            return bmp;
        }

        /// <summary>
        /// Inserts image's features into the database
        /// </summary>
        /// <param name="DBC">The controller through which features insertion will be done</param>
        private bool InsertImageFeatures(databaseController DBC)
        {
            try
            {
                string f_insert = "INSERT INTO FeaturesVector VALUES ( " + this.id;
                foreach (Feature f in featureVector)
                {
                    f_insert += "," + f.FeatureValue;
                }
                f_insert += " );";
                f_insert = f_insert.ToLower().Replace("nan", "0");
                if (DBC.IsConnected)
                {
                    DBC.CommandText = f_insert;
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
        /// Updates image's features in the database
        /// </summary>
        /// <param name="DBC">The controller through which features update will be done</param>
        private bool UpdateImageFeatures(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "UPDATE FeaturesVector SET ";
                foreach (Feature f in featureVector)
                {
                    sqlstr = sqlstr + f.FeatureName+ " = " + f.FeatureValue.ToString() + " ,";
                }
                //sqlstr = sqlstr + "Tags ='" + this.tags + "' ,";
                //sqlstr = sqlstr + "ImagePath ='" + this.url + "',";
                //sqlstr = sqlstr + "Category = " + this.cat.ID + " ,";
                //sqlstr = sqlstr + "Size = " + this.imageInfo[0] + " ,";
                //sqlstr = sqlstr + "Dimensions = '" + this.imageInfo[1] + "' ,";
                sqlstr = sqlstr.Trim(',');
                sqlstr = sqlstr + " WHERE ImageID =" + this.id + " ;";

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
        /// Deletes image's features from the database
        /// </summary>
        /// <param name="DBC">The controller through which features deletion will be done</param>
        private bool DeleteImageFeatures(databaseController DBC)
        {
            //Declarations
            string sqlstr;

            try
            {
                sqlstr = "DELETE FROM FeaturesVector WHERE ImageID= " + this.id + " ;";
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
