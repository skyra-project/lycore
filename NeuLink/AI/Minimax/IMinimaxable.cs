namespace NeuLink.AI.Minimax
{
    public interface IMinimaxable
    {
        IEvaluator GenerateNodes();
    }
}