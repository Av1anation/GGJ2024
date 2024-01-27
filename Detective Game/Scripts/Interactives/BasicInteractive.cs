using Godot;
using System;

public partial class BasicInteractive : Area2D, IInteractive
{
    public event Action OnInteracted;

    public override void _Ready()
    {
        base._Ready();

        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    public void Interact(Node reference = null)
    {
        GD.Print("I was clicked!");
        OnInteracted?.Invoke();
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
