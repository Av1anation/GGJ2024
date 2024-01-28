using Godot;
using System;

public partial class GridManager : PanelContainer
{
	Node Grid;

	[Export]
	ItemData TestItem;

	PackedScene SlotBP = GD.Load<PackedScene>("res://Scenes/InventoryTracker/SlotScene/Slot.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Grid = GetNode("MarginContainer/ItemGrid");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsKeyPressed(Key.K))
		{
			MakeSlot(TestItem);
		}
	}

	public void MakeSlot(ItemData item)
	{
		Node newSlot = SlotBP.Instantiate();

		newSlot.GetNode<TextureRect>("MarginContainer/TextureRect").Texture = item.Sprite;

        PickupItem(newSlot);
    }

    public void PickupItem(Node pickup)
	{
		Grid.AddChild(pickup);
	}
}
