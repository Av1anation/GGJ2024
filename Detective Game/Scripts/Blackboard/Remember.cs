using Godot;
using System;

[GlobalClass]
public partial class VariableChange : Resource
{
    [Export]
    public BlackboardVar Variable;

    [Export]
    public RememberOperator Operator;

    [Export]
    public int Value;

    public void ChangeVar()
    {
        switch (Operator)
        {
            default:
            case RememberOperator.SetTo:
                Variable.Value = Value;
                break;
            case RememberOperator.Add:
                Variable.Value += Value;
                break;
            case RememberOperator.Subtract:
                Variable.Value -= Value;
                break;
        }
    }

}
