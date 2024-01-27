using Godot;
using System;

public class TestInteractive : Node2D, IInteractive
{
	private const string e_MouseEntered = "mouse_entered";
	private const string e_MouseExited = "mouse_exited";

	public override void _Ready()
	{
		base._Ready();

		if (Connect(e_MouseEntered, this, nameof(OnMouseEntered)) != Error.Ok)
			GD.Print($"{e_MouseEntered} connection failed.");

		if (Connect(e_MouseExited, this, nameof(OnMouseExited)) != Error.Ok)
			GD.Print($"{e_MouseExited} connection failed.");
	}

	public void Interact(Node reference = null)
	{
		GD.Print("I was clicked!");
	}

	private void OnMouseEntered()
	{
		InteractionManager.Instance.SetInteractive(this);
	}

	private void OnMouseExited()
	{
		InteractionManager.Instance.ClearInteractive(this);
	}

    public void OnSelected()
    {
		GD.Print($"{this.Name} was selected.");
    }

    public void OnDeselected()
    {
		GD.Print($"{this.Name} was deselected.");
    }
}
