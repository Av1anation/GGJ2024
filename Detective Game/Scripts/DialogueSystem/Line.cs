using Godot;
using System;

[GlobalClass]
public partial class Line : Resource
{
    [Export]
    public string Text = "default";

    [Export]
    public Character SpeakingCharacter;
}
