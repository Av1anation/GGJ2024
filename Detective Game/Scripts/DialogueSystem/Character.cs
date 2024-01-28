using Godot;
using System;

[GlobalClass]
public partial class Character : Resource
{
    [Export]
    public string Name = "unnamed";

    [Export]
    public Texture2D Faceplate;
}
