using System;
using System.Collections.Generic;
using System.Text;
using ImageManipulation;
using MathWorks.MATLAB.NET.Arrays;

namespace XCBIR.Classes
{
    /// <summary>
    /// Interfaces between the system and the external graphical libraries for image processing purposes
    /// </summary>
    public class imageProcessor
    {
        /// <summary>
        /// The path of the resulting image
        /// </summary>
        private string newImagePath;
        /// <summary>
        /// The path of the original image
        /// </summary>
        private string originalImagePath;
        /// <summary>
        /// The stack of the undo operation
        /// </summary>
        private Stack<imageProcessorOperation> undoStack;
        /// <summary>
        /// The stack of the redo operation
        /// </summary>
        private Stack<imageProcessorOperation> redoStack;
        /// <summary>
        /// The extension class which will be used to hold image processing operations
        /// </summary>
        private ImageManipulationclass IMC;

        /// <summary>
        /// Creates new instance of imageProcessor class
        /// </summary>
        /// <param name="ImagePath">The path of the image to be processed</param>
        public imageProcessor(string ImagePath)
        {
            this.originalImagePath = ImagePath;
            undoStack = new Stack<imageProcessorOperation>();
            redoStack = new Stack<imageProcessorOperation>();
            IMC = new ImageManipulationclass();
        }

        /// <summary>
        /// Gets or sets the path of the resulting image
        /// </summary>
        public string NewImagePath
        {
            get
            {
                return newImagePath;
            }
            set
            {
                newImagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the path of the resulting image
        /// </summary>
        public string OriginalImagePath
        {
            get
            {
                return originalImagePath;
            }
            set
            {
                originalImagePath = value;
            }
        }

        /// <summary>
        /// Undoes last operation done on the image
        /// </summary>
        public void Undo()
        {
            try
            {
                imageProcessorOperation ipo;
                if (undoStack.Count > 0)
                {
                    ipo = undoStack.Pop();
                    NewImagePath = ipo.TempPath;
                    redoStack.Push(ipo);
                }
                else
                {
                    throw new Exception("Faild to undo the operation !");
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Redoes the undone operations on the image
        /// </summary>
        public void Redo()
        {
            try
            {
                imageProcessorOperation ipo;
                if (undoStack.Count > 0)
                {
                    ipo = redoStack.Pop();
                    NewImagePath = ipo.TempPath;
                    undoStack.Push(ipo);
                }
                else
                {
                    throw new Exception("Faild to Redo the operation !");
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Resets the original image
        /// </summary>
        public void ResetImage()
        {
            try
            {
                if (undoStack.Count > 0)
                {
                    undoStack.Clear();
                    redoStack.Clear();
                    newImagePath = originalImagePath;
                }
                else
                {
                    throw new Exception("You have not done any processing yet !");
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Brightens the image of this image processor
        /// </summary>
        /// <param name="Beta">Brightness factor falls in the interval [-1,+1]</param>
        public void BrightenImage(double Beta)
        {
            try
            {
                MWArray path = new MWCharArray(originalImagePath);
                MWArray res = new MWCharArray();
                res = IMC.BrightenImage(path, Beta);
                undoStack.Push(new imageProcessorOperation("Brightness Enhancement", res.ToString()));
                NewImagePath = res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enhances the contrast of the image of this image processor
        /// </summary>
        /// <param name="C">Contrast factor falls in the interval [-1,+INF[</param>
        public void EnhanceContrast(double C)
        {
            try
            {
                MWArray path = new MWCharArray(originalImagePath);
                MWArray res = new MWCharArray();
                res = IMC.contrast(path, C);
                undoStack.Push(new imageProcessorOperation("Brightness Enhancement", res.ToString()));
                NewImagePath = res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
