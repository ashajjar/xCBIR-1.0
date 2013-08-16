using System;
using System.Collections.Generic;
using System.Text;
using FeatureExtractor;
using MathWorks.MATLAB.NET.Arrays;

namespace XCBIR.Classes
{
    /// <summary>
    /// Interfaces between the system and the external processing libraries for features extraction purpose
    /// </summary>
    public class featureExtractor
    {
        /// <summary>
        /// List of features along with thier values
        /// </summary>
        private List<Feature> featureVector;
        /// <summary>
        /// The path of the image to extract features from
        /// </summary>
        private MWArray imagePath;
        /// <summary>
        /// The extension class which will be used to extract features
        /// </summary>
        private FeatureExtractorclass FEC;

        /// <summary>
        /// Creates new instance of the featureExtractor Class
        /// </summary>
        /// <param name="ImagePath">The path of the image to extract features from</param>
        public featureExtractor(string ImagePath)
        {
            this.imagePath = new MWCharArray(ImagePath);
            FEC = new FeatureExtractorclass();
        }

        /// <summary>
        /// Gets or sets list of features along with thier values
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
        /// Gets or sets the path of the image to extract features from
        /// </summary>
        public string ImagePath
        {
            get
            {
                return imagePath.ToString();
            }
            set
            {
                imagePath = new MWCharArray(value);
            }
        }

        /// <summary>
        /// Calculates all features available and returns a list of them
        /// </summary>
        public List<Feature> AllFeatures()
        {
            List<Feature> FV = new List<Feature>();
            Feature f;
            //Brain Location :
            int[] brainRect = CropBrain();

            //Color features:
            f = new Feature("Mean"          //The name of the feature in database
                          , this.Mean(brainRect[0], brainRect[1], brainRect[2], brainRect[3])     //The value of it in this object
                          );
            FV.Add(f);
            f = new Feature("StdDev", this.StandardDeviation(brainRect[0], brainRect[1], brainRect[2], brainRect[3]));
            FV.Add(f);
            f = new Feature("Entropy", this.Entropy(brainRect[0], brainRect[1], brainRect[2], brainRect[3]));
            FV.Add(f);
            f = new Feature("Energy", this.Energy(brainRect[0], brainRect[1], brainRect[2], brainRect[3]));
            FV.Add(f);
            //Shape features
            List<Feature> ShapeFV = this.ShapeFeaturesVector(brainRect[0], brainRect[1], brainRect[2], brainRect[3]);
            foreach (Feature SF in ShapeFV)
            {
                FV.Add(SF);
            }
            //Texture features
            List<Feature> TextureFV = this.TextureFeaturesVector(brainRect[0], brainRect[1], brainRect[2], brainRect[3]);
            foreach (Feature TF in TextureFV)
            {
                FV.Add(TF);
            }
            //Edge features
            List<Feature> EdgeFV = this.EdgeFeaturesVector(brainRect[0], brainRect[1], brainRect[2], brainRect[3]);
            foreach (Feature EF in EdgeFV)
            {
                FV.Add(EF);
            }

            FV.Add(new Feature("CropX", brainRect[0]));
            FV.Add(new Feature("CropY", brainRect[1]));
            FV.Add(new Feature("CropW", brainRect[2]));
            FV.Add(new Feature("CropH", brainRect[3]));
            return FV;
        }

        /// <summary>
        /// Calculates the mean of the current image
        /// </summary>
        public double Mean(int X, int Y, int W, int H)
        {
            double mean = -1;
            try
            {
                MWArray res = new MWNumericArray(1);
                res = FEC.imageMean(this.imagePath, X, Y, W, H);
                mean = double.Parse(res.ToString());
                return mean;
            }
            catch (Exception ex)
            {
                return mean;
            }
        }

        /// <summary>
        /// Calculates the entropy of the current image
        /// </summary>
        public double Entropy(int X, int Y, int W, int H)
        {
            double entropy = -1;
            try
            {
                MWArray res = new MWNumericArray(1);
                res = FEC.histEntropy(this.imagePath, X, Y, W, H);
                entropy = double.Parse(res.ToString());
                return entropy;
            }
            catch (Exception ex)
            {
                return entropy;
            }
        }

        /// <summary>
        /// Calculates the energy of the current image
        /// </summary>
        public double Energy(int X,int Y,int W,int H)
        {
            double energy = -1;
            try
            {
                MWArray res = new MWNumericArray(1);
                res = FEC.histEnergy(this.imagePath, X, Y, W, H);
                energy = double.Parse(res.ToString()); ;
                return energy;
            }
            catch (Exception ex)
            {
                return energy;
            }
        }

        /// <summary>
        /// Calculates the standard deviation of the current image
        /// </summary>
        public double StandardDeviation(int X, int Y, int W, int H)
        {
            double standardDeviation = -1;
            try
            {
                MWArray res = new MWNumericArray(1);
                res = FEC.imageStdDev(this.imagePath, X, Y, W, H);
                standardDeviation = double.Parse(res.ToString());
                return standardDeviation;
            }
            catch (Exception ex)
            {
                return standardDeviation;
            }
        }

        /// <summary>
        /// Calculates the shape features vector of the current image
        /// </summary>
        public List<Feature> ShapeFeaturesVector(int X, int Y, int W, int H)
        {
            List<Feature> FV = new List<Feature>();

            try
            {
                MWArray res = new MWCellArray(7, 1);
                res = FEC.ExtractShapeInfo(this.imagePath, X, Y, W, H);
                FV.Add(new Feature("ShapeM1", double.Parse(res[1].ToString())));
                FV.Add(new Feature("ShapeM2", double.Parse(res[2].ToString())));
                FV.Add(new Feature("ShapeM3", double.Parse(res[3].ToString())));
                FV.Add(new Feature("ShapeM4", double.Parse(res[4].ToString())));
                FV.Add(new Feature("ShapeM5", double.Parse(res[5].ToString())));
                FV.Add(new Feature("ShapeM6", double.Parse(res[6].ToString())));
                FV.Add(new Feature("ShapeM7", double.Parse(res[7].ToString())));
                return FV;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Calculates the texture features vector of the current image
        /// </summary>
        public List<Feature> TextureFeaturesVector(int X, int Y, int W, int H)
        {
            List<Feature> FV = new List<Feature>();

            try
            {
                MWArray res = new MWCellArray(24, 1);
                res = FEC.ExtractTextureInfo(this.imagePath, X, Y, W, H);
                FV.Add(new Feature("TexContrast0", double.Parse(res[1].ToString())));
                FV.Add(new Feature("TexCorrelation0", double.Parse(res[2].ToString())));
                FV.Add(new Feature("TexEnergy0", double.Parse(res[3].ToString())));
                FV.Add(new Feature("TexHomogeneity0", double.Parse(res[4].ToString())));
                FV.Add(new Feature("TexEntropy0", double.Parse(res[5].ToString())));
                FV.Add(new Feature("TexMax0", double.Parse(res[6].ToString())));

                FV.Add(new Feature("TexContrast45", double.Parse(res[7].ToString())));
                FV.Add(new Feature("TexCorrelation45", double.Parse(res[8].ToString())));
                FV.Add(new Feature("TexEnergy45", double.Parse(res[9].ToString())));
                FV.Add(new Feature("TexHomogeneity45", double.Parse(res[10].ToString())));
                FV.Add(new Feature("TexEntropy45", double.Parse(res[11].ToString())));
                FV.Add(new Feature("TexMax45", double.Parse(res[12].ToString())));

                FV.Add(new Feature("TexContrast90", double.Parse(res[13].ToString())));
                FV.Add(new Feature("TexCorrelation90", double.Parse(res[14].ToString())));
                FV.Add(new Feature("TexEnergy90", double.Parse(res[15].ToString())));
                FV.Add(new Feature("TexHomogeneity90", double.Parse(res[16].ToString())));
                FV.Add(new Feature("TexEntropy90", double.Parse(res[17].ToString())));
                FV.Add(new Feature("TexMax90", double.Parse(res[18].ToString())));

                FV.Add(new Feature("TexContrast135", double.Parse(res[19].ToString())));
                FV.Add(new Feature("TexCorrelation135", double.Parse(res[20].ToString())));
                FV.Add(new Feature("TexEnergy135", double.Parse(res[21].ToString())));
                FV.Add(new Feature("TexHomogeneity135", double.Parse(res[22].ToString())));
                FV.Add(new Feature("TexEntropy135", double.Parse(res[23].ToString())));
                FV.Add(new Feature("TexMax135", double.Parse(res[24].ToString())));

                return FV;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Calculates the edge features vector of the current image
        /// </summary>
        public List<Feature> EdgeFeaturesVector(int X, int Y, int W, int H)
        {
            List<Feature> FV = new List<Feature>();

            try
            {
                MWArray res = new MWCellArray(37, 1);
                res = FEC.CannyEdgeHistogram(this.imagePath, X, Y, W, H);
                FV.Add(new Feature("Edge1", double.Parse(res[1].ToString())));
                FV.Add(new Feature("Edge2", double.Parse(res[2].ToString())));
                FV.Add(new Feature("Edge3", double.Parse(res[3].ToString())));
                FV.Add(new Feature("Edge4", double.Parse(res[4].ToString())));
                FV.Add(new Feature("Edge5", double.Parse(res[5].ToString())));
                FV.Add(new Feature("Edge6", double.Parse(res[6].ToString())));
                FV.Add(new Feature("Edge7", double.Parse(res[7].ToString())));
                FV.Add(new Feature("Edge8", double.Parse(res[8].ToString())));
                FV.Add(new Feature("Edge9", double.Parse(res[9].ToString())));
                FV.Add(new Feature("Edge10", double.Parse(res[10].ToString())));
                FV.Add(new Feature("Edge11", double.Parse(res[11].ToString())));
                FV.Add(new Feature("Edge12", double.Parse(res[12].ToString())));
                FV.Add(new Feature("Edge13", double.Parse(res[13].ToString())));
                FV.Add(new Feature("Edge14", double.Parse(res[14].ToString())));
                FV.Add(new Feature("Edge15", double.Parse(res[15].ToString())));
                FV.Add(new Feature("Edge16", double.Parse(res[16].ToString())));
                FV.Add(new Feature("Edge17", double.Parse(res[17].ToString())));
                FV.Add(new Feature("Edge18", double.Parse(res[18].ToString())));
                FV.Add(new Feature("Edge19", double.Parse(res[19].ToString())));
                FV.Add(new Feature("Edge20", double.Parse(res[20].ToString())));
                FV.Add(new Feature("Edge21", double.Parse(res[21].ToString())));
                FV.Add(new Feature("Edge22", double.Parse(res[22].ToString())));
                FV.Add(new Feature("Edge23", double.Parse(res[23].ToString())));
                FV.Add(new Feature("Edge24", double.Parse(res[24].ToString())));
                FV.Add(new Feature("Edge25", double.Parse(res[25].ToString())));
                FV.Add(new Feature("Edge26", double.Parse(res[26].ToString())));
                FV.Add(new Feature("Edge27", double.Parse(res[27].ToString())));
                FV.Add(new Feature("Edge28", double.Parse(res[28].ToString())));
                FV.Add(new Feature("Edge29", double.Parse(res[29].ToString())));
                FV.Add(new Feature("Edge30", double.Parse(res[30].ToString())));
                FV.Add(new Feature("Edge31", double.Parse(res[31].ToString())));
                FV.Add(new Feature("Edge32", double.Parse(res[32].ToString())));
                FV.Add(new Feature("Edge33", double.Parse(res[33].ToString())));
                FV.Add(new Feature("Edge34", double.Parse(res[34].ToString())));
                FV.Add(new Feature("Edge35", double.Parse(res[35].ToString())));
                FV.Add(new Feature("Edge36", double.Parse(res[36].ToString())));
                FV.Add(new Feature("Edge37", double.Parse(res[37].ToString())));

                return FV;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about the image file
        /// </summary>
        public string GetImageInfo()
        {
            string info = "";
            try
            {
                MWArray res = new MWStructArray();
                res = FEC.getImageInfo(this.imagePath.ToString());
                info = res.ToString();
                return info;
            }
            catch (Exception ex)
            {
                return info;
            }
        }

        /// <summary>
        /// Gets the rectangle where the brain is located
        /// </summary>
        public int[] CropBrain()
        {
            int[] brainRect = new int[4];
            try
            {
                MWArray[] res = new MWArray[4];
                res = FEC.CropBrain(4, this.imagePath);
                brainRect[0] = int.Parse(res[0].ToString());
                brainRect[1] = int.Parse(res[1].ToString());
                brainRect[2] = int.Parse(res[2].ToString());
                brainRect[3] = int.Parse(res[3].ToString());

                return brainRect;
            }
            catch (Exception ex)
            {
                return brainRect;
            }
        }
    }
}
