using Godot;
using System;

[GlobalClass]
public partial class BlackboardVar : Resource
{
    public event Action OnValueChanged;

    public int Value
    {
        get => _value;
        set
        {
            if (value == _value)
                return;

            _value = value;
            OnValueChanged?.Invoke();
        }
    }

    private int _value { get; set; }
}
