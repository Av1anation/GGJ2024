using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export]
	public float Speed = 300.0f;
	[Export]
	public Vector2 InputVelocity;

	public override void _PhysicsProcess(double delta)
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		Vector2 velocity = InputVelocity;

		Velocity = velocity * Speed;
		MoveAndSlide();
	}

	private void GetInputs()
	{
		if (Input.IsActionPressed("move_Up"))
			InputVelocity.Y = 1;
		else if (Input.IsActionPressed("move_Down"))
			InputVelocity.Y = -1;
		else
			InputVelocity.Y = 0;

		if (Input.IsActionPressed("move_Right"))
			InputVelocity.X = 1;
		else if (Input.IsActionPressed("move_Left"))
			InputVelocity.X = -1;
		else
			InputVelocity.X = 0;
	}
}
