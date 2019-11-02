namespace P02._DrawingShape_Before.Contracts
{
    interface IDrawingManager
    {
        void Draw(IShape shape);

        bool IsMatch(IShape shape);
    }
}
