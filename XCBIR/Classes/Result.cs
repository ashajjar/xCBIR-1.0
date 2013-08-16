using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR
{
    /// <summary>
    /// Represents a search result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The ID of this result in the database
        /// </summary>
        private int id;
        /// <summary>
        /// The distance of this result from the example
        /// </summary>
        private double distance;

        /// <summary>
        /// Creates a new instance of Result class
        /// </summary>
        /// <param name="id">The ID of this result in the database</param>
        /// <param name="dist">The distance of this result from the example</param>
        public Result(int id, double dist)
        {
            this.id = id;
            this.distance = dist;
        }

        /// <summary>
        /// Gets or sets the ID of this result in the database
        /// </summary>
        public int ID
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
        /// Gets or sets the distance of this result from the example
        /// </summary>
        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }
    }
}
