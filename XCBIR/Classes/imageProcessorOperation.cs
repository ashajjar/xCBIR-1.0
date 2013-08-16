using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents an image processing operation
    /// </summary>
    public class imageProcessorOperation
    {
        /// <summary>
        /// The name of the operation
        /// </summary>
        private string operationName;
        /// <summary>
        /// The path where the temporary image stored after the operation is done
        /// </summary>
        private string tempPath;

        /// <summary>
        /// Creates new instance of imageProcessorOperation class
        /// </summary>
        /// <param name="Name">The name of the operation</param>
        /// <param name="Value">The value of the operation</param>
        public imageProcessorOperation(string Name, string tempPath)
        {
            this.operationName = Name;
            this.tempPath = tempPath;
        }

        /// <summary>
        /// Gets or sets the name of the operation
        /// </summary>
        public string OperationName
        {
            get
            {
                return operationName;
            }
            set
            {
                operationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the path where the temporary image stored after the operation is done
        /// </summary>
        public string TempPath
        {
            get
            {
                return tempPath;
            }
            set
            {
                tempPath = value;
            }
        }
    }
}
