using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Dialogue : Resource, IComparable<Dialogue>
{
    [Export]
    public int Priority;

    [Export]
    public ConditionalSet DialogueConditions;

    [Export]
    public Line[] LinesInDialogue;

    [Export]
    public Remember[] RememberOnCompletion;


    int IComparable<Dialogue>.CompareTo(Dialogue other)
    {
        return (Priority >= other.Priority) ? -1 : 1;
    }
}
