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

        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    public virtual void Interact(Node reference = null)
    {
        OnInteract?.Invoke();
        EmitSignal(SignalName.OnInteracted);
    }

    protected virtual void OnMouseEntered()
    {
        InteractionManager.Instance.SetInteractive(this);
    }

    protected virtual void OnMouseExited()
    {
        InteractionManager.Instance.ClearInteractive(this);
    }

    public virtual void OnSelected()
    {

    }

    public virtual void OnDeselected()
    {

    }
}
