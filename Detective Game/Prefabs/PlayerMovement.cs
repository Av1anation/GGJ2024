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

	private float StepTimer = 0f;
	private float StepCooldown = 0.3f;

	public override void _Ready()
	{
		Sprite = GetNode<AnimatedSprite2D>("Sprite");
	}

	public override void _Process(double delta)
	{
		AnimateSprite();
		StepTimer += ((float)delta);
		if(InputVelocity > Vector2.Zero|| InputVelocity < Vector2.Zero)
		{
			if(StepTimer >= StepCooldown)
			{
                PlayFootstep();
                StepTimer = 0f;
            }
		}
	}

	private void AnimateSprite()
	{
		if(InputVelocity.X == 1)
		{
			if (LastInputDir.Y < 0)
				Sprite.Play("Idle RU");
			else if (LastInputDir.Y > 0 || LastInputDir.Y == 0)
				Sprite.Play("Idle RD");
		}
		if(InputVelocity.X < 0)
		{
			if (LastInputDir.Y < 0)
				Sprite.Play("Idle LU");
			else if (LastInputDir.Y > 0 || LastInputDir.Y == 0)
				Sprite.Play("Idle LD");
		}		
		if(InputVelocity.Y < 0)
		{
			if (LastInputDir.X < 0)
				Sprite.Play("Idle LU");
			else if (LastInputDir.X > 0)
				Sprite.Play("Idle RU");
		}
		if(InputVelocity.Y > 0)
		{
			if (LastInputDir.X < 0)
				Sprite.Play("Idle LD");
			else if (LastInputDir.X > 0)
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
			InputVelocity.Y = -.5f;
		else if (Input.IsActionPressed("move_Down"))
			InputVelocity.Y = .5f;
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



	public void PlayFootstep()
	{
		AudioStreamPlayer2D audio = GetNode<AudioStreamPlayer2D>("Steps");
        audio.PitchScale = (GD.Randf() % .6f) + .8f;
		audio.Play();
	}
}
