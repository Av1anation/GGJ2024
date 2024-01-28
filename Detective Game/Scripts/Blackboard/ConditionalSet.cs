using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class ConditionalSet : Resource
{
    [Export]
    public Conditional[] Conditions;

    public bool Status { get => CheckSetStatus(); }

    private bool CheckSetStatus()
    {
        if (Conditions == null)
            return true;

        if (!Conditions.Any())
            return true;

        foreach (Conditional item in Conditions)
        {
            if (!item.Status)
                return false;
        }

        return true;
    }

}
