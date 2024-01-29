using Godot;
using System;

public partial class VariableResetter : Node
{
    [Export]
    public BlackboardVar[] Variables;

    public override void _Ready()
    {
        base._Ready();

        foreach (var v in Variables) 
        {
            v.Value = 0;
        }
    }

}
