using Godot;
using System;

public partial class GoalHud : MarginContainer
{
	[Signal]
	public delegate void ObjectiveCompleteEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsKeyPressed(Key.P))
		{
			EmitSignal(SignalName.ObjectiveComplete);
		}
	}


	private void OnObjectiveComplete()
	{
		GetNode<Label>("Score").Text = "Find Report Submitter 1/1";

    }

}
