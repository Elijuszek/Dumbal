namespace Dumbal;

public partial class Table : Control
{
    [Export] public Deck Deck { get; set; }

    public override void _Ready()
    {
        base._Ready();
        Deck.Initialize();
        Deck.Shuffle();
        AddChild(Deck.Take());
    }


}
