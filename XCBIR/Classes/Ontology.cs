using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR
{
    public class Ontology
    {
        /// <summary>
        /// Ontology ID
        /// </summary>
        private string id;
        /// <summary>
        /// Ontology name
        /// </summary>
        private string name;
        /// <summary>
        /// Contains the features of this ontology
        /// </summary>
        private List<Feature> featureVector;

        /// <summary>
        /// Creates new instance of ontology class
        /// </summary>
        /// <param name="ID">The ID of this instance</param>
        /// <param name="Name">The name of this instance</param>
        /// <param name="FV">The features vector of this instance</param>
        public Ontology(string ID, string Name, List<Feature> FV)
        {
            this.ID = ID;
            this.Name = Name;
            this.FeatureVector = FV;
        }

        /// <summary>
        /// Gets or sets ontology ID
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
        /// Gets or sets ontology name
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
        /// Gets or sets features vector of this ontology
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
    }
}
