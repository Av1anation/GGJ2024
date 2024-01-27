using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export]
	public float Speed = 300.0f;

	[Export]
	public Vector2 InputVelocity;
	public Vector2 LastInputDir;

	public AnimatedSprite2D Sprite;

	public override void _Ready()
	{
		Sprite = GetNode<AnimatedSprite2D>("Sprite");
	}

	public override void _Process(double delta)
	{
		AnimateSprite();
	}

	private void AnimateSprite()
	{
		if(InputVelocity.X == 1)
		{
			if (LastInputDir.Y == -1)
				Sprite.Play("Idle RU");
			else if (LastInputDir.Y == 1 || LastInputDir.Y == 0)
				Sprite.Play("Idle RD");
		}
		if(InputVelocity.X == -1)
		{
			if (LastInputDir.Y == -1)
				Sprite.Play("Idle LU");
			else if (LastInputDir.Y == 1 || LastInputDir.Y == 0)
				Sprite.Play("Idle LD");
		}		
		if(InputVelocity.Y == -1)
		{
			if (LastInputDir.X == -1)
				Sprite.Play("Idle LU");
			else if (LastInputDir.X == 1)
				Sprite.Play("Idle RU");
		}
		if(InputVelocity.Y == 1)
		{
			if (LastInputDir.X == -1)
				Sprite.Play("Idle LD");
			else if (LastInputDir.X == 1)
				Sprite.Play("Idle RD");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		GetInputs();
		Vector2 velocity = InputVelocity.Normalized();

		Velocity = velocity * Speed;
		MoveAndSlide();
	}

	private void GetInputs()
	{
		if (Input.IsActionPressed("move_Up"))
			InputVelocity.Y = -1;
		else if (Input.IsActionPressed("move_Down"))
			InputVelocity.Y = 1;
		else
			InputVelocity.Y = 0;

		if (Input.IsActionPressed("move_Right"))
			InputVelocity.X = 1;
		else if (Input.IsActionPressed("move_Left"))
			InputVelocity.X = -1;
		else
			InputVelocity.X = 0;

		if(InputVelocity.X != 0)
			LastInputDir.X = InputVelocity.X;
		if(InputVelocity.Y != 0)
			LastInputDir.Y = InputVelocity.Y;
	
	}
}
