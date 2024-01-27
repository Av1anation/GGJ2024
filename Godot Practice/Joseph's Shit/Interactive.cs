using Godot;
using System;

public class Interactive : Node2D, IInteractive
{
	public override void _Ready()
	{
		base._Ready();

		if (Connect("mouse_entered", this, nameof(SHIT)) != Error.Ok)
		{
			GD.Print("Fuck");
		}
		else
		{ GD.Print("SHIT"); }
	}

	public void Interact(Node reference = null)
	{
		GD.Print("I was clicked!");
	}

	private void SHIT()
	{
		GD.Print("YEET!");
	}
}
