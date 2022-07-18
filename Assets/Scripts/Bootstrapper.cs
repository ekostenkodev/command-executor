using ScoreWarrior.Test.Commands.Delete;
using ScoreWarrior.Test.Commands.Push;
using UnityEngine;

namespace ScoreWarrior.Test
{
	public class Bootstrapper : MonoBehaviour
	{
		public void Start()
		{
			IExecutionDirector director = new ExecutionDirector();
			director.RegisterExecutor<DeleteCommand, DeleteExecutor>(new DeleteExecutor());
			director.RegisterExecutor<PushCommand, PushExecutor>(new PushExecutor());

			director.Execute(new DeleteCommand(42));
			director.Execute(new PushCommand("the cake is a lie"));
		}
	}
}