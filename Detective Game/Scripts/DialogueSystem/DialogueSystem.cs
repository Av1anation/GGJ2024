using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DialogueSystem : Control
{
    public static DialogueSystem Instance { get; private set; }

    [Export]
    public TextureRect Icon;

    [Export]
    public RichTextLabel NameplateText;

    [Export]
    public RichTextLabel BodyText;


    private List<Dialogue> _possibleDialogues;
    private List<Dialogue> _validDialogues;
    private Dialogue _currentDialogue;
    private DialogueInteractive _currentInteractive;
    private int _dialogueIndex = 0;

    public override void _Ready()
    {
        Instance = this;
        Visible = false;
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

        if (_possibleDialogues.Count == 0)
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
        if (_dialogueIndex >= _currentDialogue.LinesInDialogue.Length)
            return;

        Icon.Texture = _currentDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Faceplate;
        NameplateText.Text = "[center][b]" + _currentDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Name;
        BodyText.Text = _currentDialogue.LinesInDialogue[_dialogueIndex].Text;
    }

    private void GetValidDialogues()
    {
        GD.Print($"All dialogues:\n\t{string.Join("\n\t", _possibleDialogues.Select(x => x.LinesInDialogue.First().Text))}");
        _validDialogues = new();

        foreach (Dialogue item in _possibleDialogues)
        {
            if (item.IsValidConversation)
                _validDialogues.Add(item);
        }

        _validDialogues.Sort();
        GD.Print($"Valid dialogues:\n\t{string.Join("\n\t", _validDialogues.Select(x => x.LinesInDialogue[0].Text))}");
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

        if (!_currentDialogue.IsRepeatable)
            _currentInteractive.PossibleDialoguesList.Remove(_currentDialogue);
    }

    public void SetPossibleDialogues(List<Dialogue> dialogues, DialogueInteractive callbackObj)
    {
        _possibleDialogues = dialogues;
        _currentInteractive = callbackObj;
    }
}
