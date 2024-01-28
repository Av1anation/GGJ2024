using Godot;
using System;
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
    public Dialogue TestDialogue;

    [Export]
    public BasicInteractive ClickToContinue;

    private int _dialogueIndex = 0;

    public override void _Ready()
    {
        ClickToContinue.OnInteract += OpenDialogue;
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
        DisplayDialogue();
    }

    private void ResetDialogue()
    {
        _dialogueIndex = 0;
    }

    private void DisplayDialogue()
    {
        Icon.Texture = TestDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Faceplate;
        NameplateText.Text = "[center][b]" + TestDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Name;
        BodyText.Text = TestDialogue.LinesInDialogue[_dialogueIndex].Text;
    }

    private void ShowNextLine()
    {
        if (++_dialogueIndex == TestDialogue.LinesInDialogue.Length)
        {
            Visible = false;
            return;
        }

        DisplayDialogue();
    }
}
