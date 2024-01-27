using Godot;
using System;

public partial class InteractionManager : Node
{
    public static InteractionManager Instance { get; private set; }

    public IInteractive CurrentInteractive { get; private set; }

    public override void _Ready()
    {
        GD.Print("Setting myself");
        Instance = this;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        // GD 4.2 MVP
        if (@event is not InputEventMouseButton mouseButton)
            return;

        if (mouseButton.ButtonIndex == MouseButton.Left && CurrentInteractive != null && mouseButton.Pressed)
            CurrentInteractive.Interact();
    }

    /// <summary>
    /// Sets the current interactive.
    /// </summary>
    /// <param name="interactive"></param>
    /// <returns>Returns true if set to the active interactive.</returns>
    public bool SetInteractive(IInteractive interactive)
    {
        if (CurrentInteractive != null)
        {
            if (CurrentInteractive == interactive)
                return true;
            else
                CurrentInteractive.OnDeselected();
        }

        CurrentInteractive = interactive;
        CurrentInteractive.OnSelected();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="interactive"></param>
    /// <returns>True if this object was cleared, false if something else is
    /// the current <see cref="IInteractive"/>.</returns>
    public bool ClearInteractive(IInteractive interactive)
    {
        if (CurrentInteractive == interactive)
        {
            CurrentInteractive.OnDeselected();
            CurrentInteractive = null;
            return true;
        }

        return false;
    }
}
