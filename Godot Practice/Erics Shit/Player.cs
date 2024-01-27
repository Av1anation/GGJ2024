using Godot;
using System;

public class Player : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public int Speed = 400;

    public Vector2 ScreenSize;

    [Signal]
    public delegate void Hit();

    public Vector2 StartPos;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        StartPos = ScreenSize / 2;
        Start(StartPos);

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

    private void OnBodyEntered(Node2D body)
    {
        Hide(); // Player disappears after being hit.
        EmitSignal(nameof(Hit));
        // Must be deferred as we can't change physics properties on a physics callback.
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
        GD.Print("bababooey");
    }

    public void Start(Vector2 pos)
    {
        Position = pos;
        Show();
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    }


    private void OnMouseEntered()
    {
        GD.Print("Shit Matt's Pants");
    }
}
