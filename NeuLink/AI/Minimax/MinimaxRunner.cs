using System;
using System.Linq;

namespace NeuLink.AI.Minimax
{
    public sealed class MinimaxRunner<T> where T : class, IMinimaxable
    {
        public T Game { get; }

        public MinimaxRunner(T game)
        {
            Game = game ?? throw new NullReferenceException(nameof(game));
        }

        public int Run(int depth, bool isMaximizerStart)
        {
            return Minimax(Game.GenerateNodes(), depth, int.MinValue, int.MaxValue, isMaximizerStart);
        }

        private int Minimax(IEvaluator game, int depth, int alpha, int beta, bool maximizingTurn)
        {
            if (depth == 0 || game.IsWinnable)
            {
                return game.Evaluate();
            }

            if (maximizingTurn)
            {
                var maxEval = int.MinValue;

                foreach (var child in game.Children)
                {
                    var eval = Minimax(child, depth - 1, alpha, beta, false);
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);

                    if (beta <= alpha) break;
                }

                return maxEval;
            }
            else
            {
                var minEval = int.MaxValue;

                foreach (var child in game.Children)
                {
                    var eval = Minimax(child, depth - 1, alpha, beta, true);
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);

                    if (beta <= alpha) break;
                }

                return minEval;
            }
        }
    }
}