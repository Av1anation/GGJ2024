using Godot;
using System;

public interface IInteractive
{
    public event Action OnInteract;

    void Interact(Node reference = null);
    void OnSelected();
    void OnDeselected();
}
