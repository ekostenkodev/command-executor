using System.Runtime.CompilerServices;
using ScoreWarrior.Test.Commands;

namespace ScoreWarrior.Test
{
    public class ExecutorDictionary
    {
        public bool TryGetValue<T>(out IExecutor<T> value) where T : class, ICommand
        {
            return ExecutorStorage<T>.TryGetValue(this, out value);
        }

        public void Set<T>(IExecutor<T> value) where T : class, ICommand
        {
            ExecutorStorage<T>.Set(this, value);
        }
        
        private static class ExecutorStorage<T> where T : class, ICommand
        {
            private static readonly ConditionalWeakTable<ExecutorDictionary, Executor<T>> Maps = new();

            public static void Set(ExecutorDictionary map, IExecutor<T> value)
            {
                Maps.Remove(map);
                Maps.Add(map, new Executor<T>(value));
            }

            public static bool TryGetValue(ExecutorDictionary map, out IExecutor<T> value)
            {
                if (Maps.TryGetValue(map, out var executor))
                {
                    value = executor.Value;
                    return true;
                }

                value = default;
                return false;
            }
            
            private class Executor<TCommand>
                where TCommand : class, ICommand
            {
                public readonly IExecutor<TCommand> Value;

                public Executor(IExecutor<TCommand> value)
                {
                    Value = value;
                }
            }
        }
    }
}