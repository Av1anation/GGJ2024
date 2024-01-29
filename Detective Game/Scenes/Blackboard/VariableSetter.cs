using Godot;
using System;

public partial class VariableSetter : Node
{
    [Export]
    public VariableChange VariableSet;

    public void PerformVariableSet()
    {
        VariableSet.ChangeVar();
    }
}
