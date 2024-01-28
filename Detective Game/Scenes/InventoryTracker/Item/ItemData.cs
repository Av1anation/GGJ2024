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
    bool Stackable = false;

    [Export]
    CompressedTexture2D Sprite;
}
