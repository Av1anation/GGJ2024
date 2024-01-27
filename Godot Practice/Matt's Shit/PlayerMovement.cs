using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
    [Export]
    public int Speed = 400;

    [Export]
    public Vector2 PlayerVelocity;

    public Vector2 ScreenSize;
    AnimatedSprite PlayerSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PlayerSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        ScreenSize = GetViewportRect().Size;
        PlayerVelocity = Vector2.Zero;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("Move_Right"))
            PlayerVelocity.x += 1;
        if (Input.IsActionPressed("Move_Left"))
            PlayerVelocity.x -= 1;
        if (Input.IsActionPressed("Move_Up"))
            PlayerVelocity.y -= 1; // Assuming up is negative on the y-axis
        if (Input.IsActionPressed("Move_Down"))
            PlayerVelocity.y += 1;

        PlayerVelocity = PlayerVelocity.Normalized() * Speed * delta; // Apply delta to make movement frame rate independent
        LinearVelocity = PlayerVelocity;

        // If there is no movement, let's ensure that we're not playing any 'walk' animation
        if (PlayerVelocity.Length() == 0 || PlayerSprite != null)
        {
            PlayerSprite.Stop();
            PlayerVelocity = Vector2.Zero;
        }
        else if (PlayerSprite != null)
        {
            // Play your walk animation here
            PlayerSprite.Play();
        }
    }

}
