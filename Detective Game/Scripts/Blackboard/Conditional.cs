using Godot;
using System;

[GlobalClass]
public partial class Conditional : Resource
{
    [Export]
    public BlackboardVar Variable;

    [Export]
    public Operator Operator;

    [Export]
    public int Comparator;

    public bool Status { get => CheckStatus(); }

    private bool CheckStatus()
    {
        switch (Operator)
        {
            case Operator.Equals:
                return Variable.Value == Comparator;
            case Operator.NotEquals:
                return Variable.Value != Comparator;
            case Operator.GreaterThan:
                return Variable.Value > Comparator;
            case Operator.LessThan:
                return Variable.Value < Comparator;
            case Operator.GreaterThanOrEqualTo:
                return Variable.Value >= Comparator;
            case Operator.LessThanOrEqualTo:
                return Variable.Value <= Comparator;
            default:
                GD.PrintErr("Undefined status comparison.");
                return false;
        }
    }
}
