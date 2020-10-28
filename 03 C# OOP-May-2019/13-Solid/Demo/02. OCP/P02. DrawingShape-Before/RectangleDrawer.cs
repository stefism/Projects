using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before
{
    public class RectangleDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            Rectangle rectangle = shape as Rectangle;
            Console.WriteLine("Rectangle drawer");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Rectangle)
            {
                return true;
            }

            return false;
        }
    }
}
