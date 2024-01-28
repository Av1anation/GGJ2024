using Godot;
using System;

public partial class GoalHud : MarginContainer
{
	[Signal]
	public delegate void ObjectiveCompleteEventHandler();

	[Export]
	public Texture2D VictoryTexture{ get; set; }

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
		GetNode<TextureRect>("Score").Texture = VictoryTexture;

    }

}
