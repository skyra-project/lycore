using System.Collections.Generic;

namespace NeuLink.AI.Minimax
{
    public interface IEvaluator
    {
        int Evaluate();
        IEnumerable<IEvaluator> Children { get; }
        bool IsWinnable { get; }
    }
}