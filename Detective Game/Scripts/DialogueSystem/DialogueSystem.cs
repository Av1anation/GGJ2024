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

    public override void _Ready()
    {
        DisplayDialogue(TestDialogue);
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        Icon.Texture = dialogue.LinesInDialogue.First().SpeakingCharacter.Faceplate;
        NameplateText.Text = "[center][b]" + dialogue.LinesInDialogue.First().SpeakingCharacter.Name;
        BodyText.Text = dialogue.LinesInDialogue.First().Text;
    }
}
