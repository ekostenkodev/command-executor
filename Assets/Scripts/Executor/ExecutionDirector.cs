using System;
using ScoreWarrior.Test.Commands;

namespace ScoreWarrior.Test
{
    public class ExecutionDirector : IExecutionDirector
    {
        private readonly ExecutorDictionary _executorByExecutableType;

        public ExecutionDirector()
        {
            _executorByExecutableType = new ExecutorDictionary();
        }

        public void RegisterExecutor<TCommand, TExecutor>(TExecutor executor)
            where TCommand : class, ICommand
            where TExecutor : class, IExecutor<TCommand>
        {
            if (_executorByExecutableType.TryGetValue<TCommand>(out var value))
            {
                throw new ArgumentException($"Executor for command {nameof(TCommand)} already registered: {value.GetType()}");
            }

            _executorByExecutableType.Set(executor);
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            if (_executorByExecutableType.TryGetValue<TCommand>(out var executor))
            {
                executor.Execute(command);
            }
        }
    }
}