using Godot;
using System;

public partial class CreditScene : PanelContainer
{

    private void OnMenuPressed()
    {

        GetTree().ChangeSceneToFile("res://Scenes/MainMenu/MainMenu.tscn");

    }
}
