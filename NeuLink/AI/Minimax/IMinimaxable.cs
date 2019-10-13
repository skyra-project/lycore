namespace NeuLink.AI.Minimax
{
    public interface IMinimaxable
    {
        IEvaluator<T> GenerateNodes<T>();
        
    }
}