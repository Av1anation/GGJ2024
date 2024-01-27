using Godot;
using System;

public class Player : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public int Speed = 400;

    public Vector2 ScreenSize;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Vector2 velocity = Vector2.Zero;

        if(Input.IsActionPressed("move_Right"))
        {
            velocity.x += 1;
        }
        if (Input.IsActionPressed("move_Left"))
        {
            velocity.x -= 1;
        }
        if (Input.IsActionPressed("move_Up"))
        {
            velocity.y -= 1;
        }
        if (Input.IsActionPressed("move_Down"))
        {
            velocity.y += 1;
        }


        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
            );

    }
}
