using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        private double Length 
        {
            get => length;

            set 
            {
                ValidateData(value, "Length cannot be zero or negative.");

                length = value;
            }
        }

        private double Width
        {
            get => width;

            set
            {
                ValidateData(value, "Width cannot be zero or negative.");

                width = value;
            }
        }

        private double Height
        {
            get => height;

            set
            {
                ValidateData(value, "Height cannot be zero or negative.");

                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double CalculateSurfaceArea(Box box)
        {
            double surfaceArea = ((box.length * box.width) * 2) 
                + ((box.length * box.height) * 2) + ((box.width * box.height) * 2);

            return surfaceArea;
        }

        public double CalculateLateralSurfaceArea(Box box)
        {
            double lateralSurfaceArea = ((box.length * box.height) * 2) 
                + ((box.width * box.height) * 2);

            return lateralSurfaceArea;
        }

        public double CalculateVolume(Box box)
        {
            double volume = box.length * box.width * box.height;

            return volume;
        }

        private static void ValidateData(double value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
