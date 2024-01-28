using Godot;
using System;

public partial class BasicInteractive : Area2D, IInteractive
{
    public event Action OnInteract;

    [Signal]
    public delegate void OnInteractedEventHandler();

    public override void _Ready()
    {
        base._Ready();

        GD.Print("Setting up mouse events");

        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    public void Interact(Node reference = null)
    {
        GD.Print("I was clicked!");
        OnInteract?.Invoke();
        EmitSignal(SignalName.OnInteracted);
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
        GD.Print($"{Name} was selected.");
    }

    public void OnDeselected()
    {
        GD.Print($"{Name} was deselected.");
    }
}
