using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuLink.AI.Minimax
{
    public interface IEvaluator<T> where T : class, IMinimaxable
    {
        int Evaluate();
        IEnumerable<IEvaluator<T>> Children { get; }
        bool IsWinnable { get; }
        Task MakeMove(T game);
    }
}