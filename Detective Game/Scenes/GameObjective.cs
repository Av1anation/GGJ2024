using Godot;
using System;

public partial class GameObjective : Area2D
{
	[Export]
	Conditional VictoryCondition;

	[Signal]
	public delegate void OnGameFinishedEventHandler();
	[Signal]
	public delegate void OnGameUnfinishedEventHandler();

    public override void _Ready()
    {
		base._Ready();
		AreaEntered += (x) => CheckProgress();
    }

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
