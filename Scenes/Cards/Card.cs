namespace Dumbal;

public partial class Card : Control
{
    [Export] public TextureRect Texture { get; set; }
    public CardType Type { get; set; } = CardType.Clubs;
    public CardValue Value { get; set; } = CardValue.Queen;

    public override void _Ready()
    {
        base._Ready();
        string path = string.Format("res://Sprites/Cards/{0}_of_{1}.png", Value.ToString().ToLower(), Type.ToString().ToLower());
        Texture.Texture = ResourceLoader.Load<Texture2D>(path);
    }
}
