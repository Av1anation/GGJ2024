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

    public bool IsActive = false;


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
        GetTree().Paused = true;
        IsActive = true;

        GetValidDialogues();

        if (_possibleDialogues.Count == 0)
            return;

        _currentDialogue = GetRandomDialogueOfPriority(_validDialogues.First().Priority);
        
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
        _validDialogues = new();

        foreach (Dialogue item in _possibleDialogues)
        {
            if (item.IsValidConversation)
                _validDialogues.Add(item);
        }

        _validDialogues.Sort();
    }

    public void ShowNextLine()
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
        GetTree().Paused = false;
        IsActive = false;

        foreach (Remember item in _currentDialogue.RememberOnCompletion)
        {
            item.DoRemember();
        }

        _currentInteractive.DialogueFinished();

        if (!_currentDialogue.IsRepeatable)
            _currentInteractive.PossibleDialoguesList.Remove(_currentDialogue);
    }

    public void SetPossibleDialogues(List<Dialogue> dialogues, DialogueInteractive callbackObj)
    {
        _possibleDialogues = dialogues;
        _currentInteractive = callbackObj;
    }

    private Dialogue GetRandomDialogueOfPriority(int priority)
    {
        List<Dialogue> dialogues = _possibleDialogues.Where(x => x.Priority == priority).ToList();
        int rand = (int)GD.Randi() % dialogues.Count;

        return dialogues[rand];
    }
}
