using Godot;
using System;

public interface IInteractive
{
    public event Action OnInteracted;

    void Interact(Node reference = null);
    void OnSelected();
    void OnDeselected();
}
