using Godot;
using System;

public partial class GameObjective : Node2D
{
	[Export]
	Conditional VictoryCondition;

	[Signal]
	public delegate void OnGameFinishedEventHandler();
	[Signal]
	public delegate void OnGameUnfinishedEventHandler();

	public void CheckProgress()
	{
		if(VictoryCondition.Status)
		{
            EmitSignal(SignalName.OnGameFinished);
        }
		else
		{
            EmitSignal(SignalName.OnGameUnfinished);
        }
	}
}
