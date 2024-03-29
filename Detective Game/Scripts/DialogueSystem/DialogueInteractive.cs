using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public partial class DialogueInteractive : BasicInteractive
{
    [Export]
    public Dialogue[] PossibleDialogues;

    [Signal]
    public delegate void OnDialogueFinishedEventHandler();

    public List<Dialogue> PossibleDialoguesList;


    public override void _Ready()
    {
        base._Ready();

        PossibleDialoguesList = PossibleDialogues.ToList();
    }

    public void IntroCutscene()
    {
        DelayInvocation(Interact, 0.5f);
    }

    private async void DelayInvocation(Action callback, float seconds)
    {
        await Task.Delay((int)(seconds * 1000));

        callback();
    }

    public void Interact()
    {
        Interact(reference: null);
    }

    public override void Interact(Node reference = null)
    {
        base.Interact(reference);

        if (DialogueSystem.Instance == null)
        {
            GD.PrintErr("No dialogue system in scene!");
            return;
        }

        if (DialogueSystem.Instance.IsActive)
            DialogueSystem.Instance.ShowNextLine();
        else
            DialogueSystem.Instance.SetPossibleDialogues(PossibleDialoguesList, this);

        DialogueSystem.Instance.OpenDialogue();
    }

    public void DialogueFinished()
    {
        EmitSignal(SignalName.OnDialogueFinished);
    }

}

public static class WaitClass
{
    public static SignalAwaiter Wait(this Node n, float time)
    {
        return n.ToSignal(n.GetTree().CreateTimer(time), "timeout");
    }
}