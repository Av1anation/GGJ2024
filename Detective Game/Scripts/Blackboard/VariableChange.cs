using Godot;
using System;

[GlobalClass]
public partial class VariableChange : Resource
{
    [Export]
    public BlackboardVar Variable { get; set; }

    [Export]
    public RememberOperator Operator {  get; set; }

    [Export]
    public int Value { get; set; }

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
