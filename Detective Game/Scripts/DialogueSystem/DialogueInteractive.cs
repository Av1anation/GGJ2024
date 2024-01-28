using Godot;
using System;

public partial class DialogueInteractive : BasicInteractive
{
    [Export]
    public Dialogue[] PossibleDialogues;

    public override void Interact(Node reference = null)
    {
        base.Interact(reference);

        if (DialogueSystem.Instance == null)
        {
            GD.PrintErr("No dialogue system in scene!");
            return;
        }

        DialogueSystem.Instance.SetPossibleDialogues(PossibleDialogues);
        DialogueSystem.Instance.OpenDialogue();
    }

}
