using Godot;
using System;

[GlobalClass]
public partial class ItemData : Resource
{
    [Export]
    string Name = "";

    [Export(PropertyHint.MultilineText)]
    string Description = "";

    [Export]
    public bool Stackable = false;

    [Export]
    public CompressedTexture2D Sprite;
}
