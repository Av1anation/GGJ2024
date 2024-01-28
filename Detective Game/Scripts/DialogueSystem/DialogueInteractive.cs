using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DialogueInteractive : BasicInteractive
{
    [Export]
    public Dialogue[] PossibleDialogues;

    public List<Dialogue> PossibleDialoguesList;


    public override void _Ready()
    {
        base._Ready();

        PossibleDialoguesList = PossibleDialogues.ToList();
    }

    public override void Interact(Node reference = null)
    {
        base.Interact(reference);

        if (DialogueSystem.Instance == null)
        {
            GD.PrintErr("No dialogue system in scene!");
            return;
        }

        DialogueSystem.Instance.SetPossibleDialogues(PossibleDialoguesList, this);
        DialogueSystem.Instance.OpenDialogue();
    }

}
