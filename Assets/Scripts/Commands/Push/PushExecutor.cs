using UnityEngine;

namespace ScoreWarrior.Test.Commands.Push
{
	internal class PushExecutor : IExecutor<PushCommand>
	{
		public void Execute(PushCommand pushCommand)
		{
			Debug.Log($"Push with name: {pushCommand.Name}");
		}
	}
}