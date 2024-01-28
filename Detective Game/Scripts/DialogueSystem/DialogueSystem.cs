using Godot;
using System;
using System.Linq;

public partial class DialogueSystem : Node
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
        ClickToContinue.OnInteract += ShowNextLine;
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        Icon.Texture = TestDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Faceplate;
        NameplateText.Text = "[center][b]" + TestDialogue.LinesInDialogue[_dialogueIndex].SpeakingCharacter.Name;
        BodyText.Text = TestDialogue.LinesInDialogue[_dialogueIndex].Text;
    }

    private void ResetDialogue()
    {
        _dialogueIndex = 0;
    }

    private void ShowNextLine()
    {
        _dialogueIndex = Mathf.Clamp(_dialogueIndex + 1, 0, TestDialogue.LinesInDialogue.Length);
        DisplayDialogue();
    }
}
