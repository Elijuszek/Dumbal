namespace Dumbal;

public partial class Table : Control
{
    [Export] public Deck Deck { get; set; }
    public Card PreviousCard { get; set; }
    public Card CurrentCard { get; set; }

    public Array<Player> players = new Array<Player>();
    public override void _Ready()
    {
        base._Ready();
        Deck.Initialize();
        Deck.Shuffle();
        AddChild(Deck.Take());
    }


    public void PlaceCard(Card placedCard)
    {
        PreviousCard = CurrentCard;
        CurrentCard = placedCard;
    }

    public void TakeLast()
    {

    }



    public void DrawFromDeck()
    {

    }

}
