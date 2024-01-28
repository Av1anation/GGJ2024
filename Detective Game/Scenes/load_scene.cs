using Godot;
using System;

public partial class load_scene : Node2D
{
	[Export]
	string ScenePath;

	public void LoadScene()
	{
		GetTree().ChangeSceneToFile(ScenePath);
	}
}
