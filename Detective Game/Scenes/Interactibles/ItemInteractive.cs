using Godot;
using System;

public partial class ItemInteractive : BasicInteractive
{
	[Export]
	public GridManager GM;

	[Export]
	public ItemData Item;

    [Export]
    VariableChange[] Blackboard;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void Interact(Node reference = null)
    {
        base.Interact(reference);
		GM.MakeSlot(Item);

        foreach (var item in Blackboard) 
        {
            item.ChangeVar();
        }

        QueueFree();
    }
}
