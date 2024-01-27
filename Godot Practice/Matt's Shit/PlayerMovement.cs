using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
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
        this.AddForce(new Vector2(0, 0), new Vector2(0, 1));
    }
}
