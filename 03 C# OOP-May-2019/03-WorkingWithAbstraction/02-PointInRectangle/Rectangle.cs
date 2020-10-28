namespace _02_PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            if (point.X >= TopLeft.X && point.X <= BottomRight.X 
                && point.Y >= TopLeft.Y && point.Y <= BottomRight.Y)
            {
                return true;
            }

            return false;
        }
    }
}
