using Godot;
using System;

public class TestInteractive : Node2D, IInteractive
{
	public override void _Ready()
	{
		base._Ready();

		if (Connect("mouse_entered", this, nameof(OnMouseEntered)) != Error.Ok)
			GD.Print("Mouse entered connection failed.");

		if (Connect("mouse_exited", this, nameof(OnMouseExited)) != Error.Ok)
			GD.Print("Mouse exited connection failed.");
	}

	public void Interact(Node reference = null)
	{
		GD.Print("I was clicked!");
	}

	private void OnMouseEntered()
	{
		
	}

	private void OnMouseExited()
	{

	}
}
