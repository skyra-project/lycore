using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuLink.AI.Minimax
{
    public interface IEvaluator
    {
        int Evaluate();
        IEnumerable<IEvaluator> Children { get; }
        bool IsWinnable { get; }
        Task MakeMove<T>(T game);
    }
}