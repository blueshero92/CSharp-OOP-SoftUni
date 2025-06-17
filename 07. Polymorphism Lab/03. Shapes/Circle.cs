using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }
        public override double CalculateArea()
        {
            return Math.PI * (Radius * Radius);
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Math.PI * Radius);
        }

        public override string Draw()
        {
            return $"Drawing {string.Format(nameof(Circle))}";
        }
    }
}
