using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData.Models
{
    public class Box
    {
        private const string LessOrEqualToZeroArgumentExceptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return this.length; }

            private set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException(string.Format(LessOrEqualToZeroArgumentExceptionMessage, nameof(Length)));
                }

                this.length = value; 
            }
        }

        public double Width
        {
            get { return this.width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(LessOrEqualToZeroArgumentExceptionMessage, nameof(Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(LessOrEqualToZeroArgumentExceptionMessage, nameof(Height)));
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Height + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
