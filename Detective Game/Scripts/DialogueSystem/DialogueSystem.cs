using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DialogueSystem : Control
{
    [Export]
    public TextureRect Icon;

    [Export]
    public RichTextLabel NameplateText;

    [Export]
    public RichTextLabel BodyText;

    [Export]
    public Dialogue[] PossibleDialogues;

    [Export]
    public BasicInteractive InteractiveNPC;


    private List<Dialogue> _validDialogues;
    private Dialogue _currentDialogue;
    private int _dialogueIndex = 0;

    public override void _Ready()
    {
        InteractiveNPC.OnInteract += OpenDialogue;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event is not InputEventKey key)
            return;

        if (key.Keycode == Key.E && key.IsPressed())
            ShowNextLine();
    }

    public void OpenDialogue()
    {
        ResetDialogue();
        Visible = true;

        GetValidDialogues();

        if (PossibleDialogues.Length == 0)
            return;

        _currentDialogue = _validDialogues.First();
        
        DisplayDialogue();
    }

    private void ResetDialogue()
    {
        _dialogueIndex = 0;
    }

    private void DisplayDialogue()
    {
        Icon.Texture = _currentDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Faceplate;
        NameplateText.Text = "[center][b]" + _currentDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Name;
        BodyText.Text = _currentDialogue.LinesInDialogue[_dialogueIndex].Text;
    }

    private void GetValidDialogues()
    {
        _validDialogues = new();

        foreach (Dialogue item in PossibleDialogues)
        {
            if (item.DialogueConditions.Status)
                _validDialogues.Add(item);
        }

        _validDialogues.Sort();

        GD.Print($"Dialogues sorted to {string.Join(", ", _validDialogues.Select(x => x.Priority))}");
    }

    private void ShowNextLine()
    {
        if (++_dialogueIndex == _currentDialogue.LinesInDialogue.Length)
        {
            FinishDialogue();
            return;
        }

        DisplayDialogue();
    }

    private void FinishDialogue()
    {
        Visible = false;

        foreach (Remember item in _currentDialogue.RememberOnCompletion)
        {
            item.DoRemember();
        }
    }
}
