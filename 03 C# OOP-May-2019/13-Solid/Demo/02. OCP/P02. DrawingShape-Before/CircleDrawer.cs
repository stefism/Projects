using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before
{
    public class CircleDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            Circle circle = shape as Circle;
            Console.WriteLine("Circle drawed");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Circle)
            {
                return true;
            }

            return false;
        }
    }
}
