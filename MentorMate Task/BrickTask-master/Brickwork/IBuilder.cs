namespace Brickwork
{
    public interface IBuilder
    {
        int Rows { get; set; }

        int Colls { get; set; }

        bool CreateFirstLayer(int[] input, int row);

        bool TryBuildNewLayer();

        int[,] GetLastLayer();

        void ValidateBricks();

        string PrintResultWithSymbols();

        string PrintResult();

        void CreateBase();
    }
}
