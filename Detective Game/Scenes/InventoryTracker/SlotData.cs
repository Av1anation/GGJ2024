using Godot;
using System;

[GlobalClass]
public partial class SlotData : Resource
{
    int MaxStackSize = 99;

    [Export]
    ItemData MyItem;

    [Export(PropertyHint.Range, "0,MaxStackSize,")]
    int quantity = 1;
}
