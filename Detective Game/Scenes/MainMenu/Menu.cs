using Godot;
using System;

public partial class Menu : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPlayPressed()
	{

		GetTree().ChangeSceneToFile("res://Scenes/Tenative First BACKUP2.tscn");

    }

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
