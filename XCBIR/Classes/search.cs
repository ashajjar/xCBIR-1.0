using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FeatureExtractor;
using MathWorks.MATLAB.NET.Arrays;
using System.Collections;

namespace XCBIR.Classes
{
    /// <summary>
    /// Processing core of the system holds the main operations
    /// </summary>
    public class search
    {
        /// <summary>
        /// List of search results
        /// </summary>
        private List<string[]> resultsList;
        /// <summary>
        /// The path of the example image
        /// </summary>
        private string exampleImagePath;

        /// <summary>
        /// Creates new instance of search class
        /// </summary>
        public search()
        {
            resultsList = new List<string[]>();
            exampleImagePath = "";
            exampleImagePath = exampleImagePath + "";
        }

        /// <summary>
        /// Gets the list of search results
        /// </summary>
        public List<string[]> ResultsList
        {
            get
            {
                return resultsList;
            }
        }

        /// <summary>
        /// Finds an image that matches the example image
        /// </summary>
        /// <param name="ExampleImagePath">The path of the example image</param>
        /// <param name="DBC">The controller through which the search will be done</param>
        public List<string[]> SearchByExample(string ExampleImagePath, databaseController DBC, double Max, double Min)
        {
            try
            {
                List<string[]> res = new List<string[]>();

                //Get the features of the example image
                featureExtractor fe = new featureExtractor(ExampleImagePath);
                List<Feature> fv = fe.AllFeatures();

                double area = fv[fv.Count - 1].FeatureValue * fv[fv.Count - 2].FeatureValue;
                double MaxArea = area * Max;
                double MinArea = area * Min;

                fv.RemoveAt(fv.Count - 1);
                fv.RemoveAt(fv.Count - 1);
                fv.RemoveAt(fv.Count - 1);
                fv.RemoveAt(fv.Count - 1);

                //Example color features
                double[] exCF = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    exCF[i] = fv[i].FeatureValue;
                }
                
                //Example shape features
                double[] exSF = new double[7];
                for (int i = 4; i < 11; i++)
                {
                    exSF[i - 4] = fv[i].FeatureValue;
                }
                
                //Example texture features
                double[] exTF = new double[24];
                for (int i = 11; i < 35; i++)
                {
                    exTF[i - 11] = fv[i].FeatureValue;
                }

                //Example edge features
                double[] exEF = new double[37];
                for (int i = 35; i < 72; i++)
                {
                    exEF[i - 35] = fv[i].FeatureValue;
                }

                //Calculate similarities between example image and images in the database
                FeatureExtractorclass fec = new FeatureExtractorclass();
                MWArray mwXCF = new MWNumericArray(exCF.Length, 1, exCF);
                MWArray mwXSF = new MWNumericArray(exSF.Length, 1, exSF);
                MWArray mwXTF = new MWNumericArray(exTF.Length, 1, exTF);
                MWArray mwXEF = new MWNumericArray(exEF.Length, 1, exEF);

                DBC.CommandText = "SELECT * FROM FeaturesVector where (CropH*CropW >=" + MinArea.ToString() + ") AND (CropH*CropW <="+ MaxArea.ToString() + ");";
                DataSet ds = DBC.ExecuteQuery();
                if (ds.Tables[0].Rows.Count < 1)
                    throw new Exception("The database is empty or there are no matches!");
                
                //Calculate similiraties for each group of feature . . .
                List<Result> ColorSimilarties = new List<Result>();
                List<Result> ShapeSimilarties = new List<Result>();
                List<Result> TextureSimilarties = new List<Result>();
                List<Result> EdgeSimilarties = new List<Result>();

                double[] Cfrow;
                double[] Sfrow;
                double[] Tfrow;
                double[] Efrow;
                
                MWArray mwRes = new MWNumericArray(1);
                MWArray mwCC;   //Color features for current image
                MWArray mwCS;   //Shape features for current image
                MWArray mwCT;   //Texture features for current image
                MWArray mwCE;   //Edge features for current image

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    int ID = int.Parse(ds.Tables[0].Rows[j].ItemArray[0].ToString());
                    
                    //Current image color features
                    Cfrow = new double[4];
                    for (int i = 1; i < 5; i++)
                    {
                        Cfrow[i - 1] = double.Parse(ds.Tables[0].Rows[j].ItemArray[i].ToString());
                    }
                    mwCC = new MWNumericArray(Cfrow.Length, 1, Cfrow);
                    mwRes = fec.minkowski(mwXCF, mwCC, 4);

                    double Distance = double.Parse(mwRes.ToString());
                    Result sim = new Result(ID, Distance);
                    ColorSimilarties.Add(sim);

                    //Current image shape features
                    Sfrow = new double[7];
                    for (int i = 5; i < 12; i++)
                    {
                        Sfrow[i - 5] = double.Parse(ds.Tables[0].Rows[j].ItemArray[i].ToString());
                    }
                    mwCS = new MWNumericArray(Sfrow.Length, 1, Sfrow);
                    mwRes = fec.minkowski(mwXSF, mwCS, 4);

                    Distance = double.Parse(mwRes.ToString());
                    sim = new Result(ID, Distance);
                    ShapeSimilarties.Add(sim);

                    //Current image texture features
                    Tfrow = new double[24];
                    for (int i = 12; i < 36; i++)
                    {
                        Tfrow[i - 12] = double.Parse(ds.Tables[0].Rows[j].ItemArray[i].ToString());
                    }
                    mwCT = new MWNumericArray(Tfrow.Length, 1, Tfrow);
                    mwRes = fec.minkowski(mwXTF, mwCT, 4);

                    Distance = double.Parse(mwRes.ToString());
                    sim = new Result(ID, Distance);
                    TextureSimilarties.Add(sim);

                    //Current image edge features
                    Efrow = new double[37];
                    for (int i = 36; i < 73; i++)
                    {
                        Efrow[i - 36] = double.Parse(ds.Tables[0].Rows[j].ItemArray[i].ToString());
                    }
                    mwCE = new MWNumericArray(Efrow.Length, 1, Efrow);
                    mwRes = fec.minkowski(mwXEF, mwCE, 4);

                    Distance = double.Parse(mwRes.ToString());
                    sim = new Result(ID, Distance);
                    EdgeSimilarties.Add(sim);
                }

                ShapeSimilarties = sortList(ShapeSimilarties);

                double resAvg = ListAverag(ShapeSimilarties);
                while (ShapeSimilarties[ShapeSimilarties.Count - 1].Distance > resAvg)
                {
                    Result R = ShapeSimilarties[ShapeSimilarties.Count - 1];
                    ShapeSimilarties.RemoveAt(ShapeSimilarties.Count - 1);
                    for (int r = 0; r < EdgeSimilarties.Count; r++)
                    {
                        if (EdgeSimilarties[r].ID == R.ID)
                        { 
                            EdgeSimilarties.RemoveAt(r);
                            TextureSimilarties.RemoveAt(r);
                            ColorSimilarties.RemoveAt(r);
                            break;
                        }
                    }
                }
                
                EdgeSimilarties = sortList(EdgeSimilarties);

                resAvg = ListAverag(EdgeSimilarties);
                while (EdgeSimilarties[EdgeSimilarties.Count - 1].Distance > resAvg)
                {
                    Result R = EdgeSimilarties[EdgeSimilarties.Count - 1];
                    EdgeSimilarties.RemoveAt(EdgeSimilarties.Count - 1);
                    for (int r = 0; r < TextureSimilarties.Count; r++)
                    {
                        if (TextureSimilarties[r].ID == R.ID)
                        {
                            TextureSimilarties.RemoveAt(r);
                            ColorSimilarties.RemoveAt(r);
                            break;
                        }
                    }
                }
                
                TextureSimilarties = sortList(TextureSimilarties);

                resAvg = ListAverag(TextureSimilarties);
                while (TextureSimilarties[TextureSimilarties.Count - 1].Distance > resAvg)
                {
                    Result R = TextureSimilarties[TextureSimilarties.Count - 1];
                    TextureSimilarties.RemoveAt(TextureSimilarties.Count - 1);
                    for (int r = 0; r < ColorSimilarties.Count; r++)
                    {
                        if (ColorSimilarties[r].ID == R.ID)
                        {
                            ColorSimilarties.RemoveAt(r);
                            break;
                        }
                    }
                }

                ColorSimilarties = sortList(ColorSimilarties);

                resAvg = ListAverag(ColorSimilarties);
                while (ColorSimilarties[ColorSimilarties.Count - 1].Distance > resAvg)
                {
                    ColorSimilarties.RemoveAt(ColorSimilarties.Count - 1);
                }

                List<Result> similarties = ColorSimilarties;
                
                //Ranking :
                double farestImg = (double)similarties[similarties.Count - 1].Distance;   //The worst match.
                double rank = 0;
                string[] resStr;

                for (int i = 0; i < similarties.Count; i++)
                {
                    resStr = new string[4];
                    int x = similarties[i].ID;
                    
                    DBC.CommandText = "SELECT I.FileName, S.FolderPath ";
                    DBC.CommandText += "FROM Image AS I INNER JOIN Series AS S ON FLOOR(I.ImageID / 100) = S.SID ";
                    DBC.CommandText += "WHERE (I.ImageID = " + x + ")";

                    ds = DBC.ExecuteQuery();
                    rank = (1 - ((double)similarties[i].Distance / farestImg)) * 100;
                    rank = Math.Round(rank, 5);
                    resStr[0] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    resStr[1] = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    resStr[2] = " - " + rank.ToString() + "%";
                    resStr[3] = x.ToString();
                    res.Add(resStr);
                    resStr = null;
                }
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Sorts the results of this search
        /// </summary>
        /// <param name="similarties">The list of results to be sorted</param>
        private List<Result> sortList(List<Result> similarties)
        {
            try
            {
                List<Result> res = new List<Result>();

                while (similarties.Count > 0)
                {
                    res.Add(MinResult(ref similarties));
                }

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the minimum result (The best match)
        /// </summary>
        /// <param name="similarties">The list of results to get the minimum of it</param>
        private Result MinResult(ref List<Result> similarties)
        {
            try
            {
                Result min = new Result(0, Double.MaxValue);
                int idx = -1;
                for (int i = 0; i < similarties.Count; i++)
                {
                    if (similarties[i].Distance <= min.Distance)
                    {
                        min = similarties[i];
                        idx = i;
                        if (min.Distance == 0)
                        {
                            break;
                        }
                    }
                }
                similarties.RemoveAt(idx);
                return min;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the average of the results
        /// </summary>
        /// <param name="similarties">The list of results to get its average</param>
        private double ListAverag(List<Result> similarties)
        {
            double avg = 0.0;
            try
            {
                double sum=0;
                for (int i = 0; i < similarties.Count; i++)
                {
                    sum += similarties[i].Distance;
                }
                avg = sum / similarties.Count;
                return avg;
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Finds an image that matches a semantic query
        /// </summary>
        /// <param name="query">The semantic query</param>
        /// <param name="DBC">The controller through which the search will be done</param>
        public List<string[]> SearchBySemantic(string Query, databaseController DBC)
        {
            List<string[]> res = new List<string[]>();

            return res;
        }
    }
}
