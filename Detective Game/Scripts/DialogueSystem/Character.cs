using Godot;
using System;

[GlobalClass]
public partial class Character : Resource
{
    [Export]
    public string Name;

    [Export]
    public Texture2D Faceplate;
}
