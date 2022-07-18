using ScoreWarrior.Test.Commands;

namespace ScoreWarrior.Test
{
	public interface IExecutionDirector
	{
		void RegisterExecutor<TCommand, TExecutor>(TExecutor executor)
				where TCommand : class, ICommand
				where TExecutor : class, IExecutor<TCommand>;

		void Execute<TCommand>(TCommand command) where TCommand : class, ICommand;
	}
}