using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR
{
    /// <summary>
    /// Represents an image feature
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Image feature name
        /// </summary>
        private string featureName;
        /// <summary>
        /// Image feature value
        /// </summary>
        private double featureValue;

        /// <summary>
        /// Creates new instance of Feature struct
        /// </summary>
        /// <param name="Name">Feature name</param>
        /// <param name="Value">Feature value</param>
        public Feature(string Name, double Value)
        {
            this.featureName = Name;
            this.featureValue = Value;
        }

        /// <summary>
        /// Gets or sets image feature name
        /// </summary>
        public string FeatureName
        {
            get
            {
                return featureName;
            }
            set
            {
                featureName = value;
            }
        }

        /// <summary>
        /// Gets or sets image feature vlaue
        /// </summary>
        public double FeatureValue
        {
            get
            {
                return featureValue;
            }
            set
            {
                featureValue = value;
            }
        }
    }
}
