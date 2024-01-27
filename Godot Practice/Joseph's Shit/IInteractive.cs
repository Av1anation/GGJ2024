using Godot;
using System;

public interface IInteractive
{
    void Interact(Node reference = null);
    void OnSelected();
    void OnDeselected();
}
