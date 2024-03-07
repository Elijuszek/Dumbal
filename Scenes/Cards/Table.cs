namespace Dumbal;

public partial class Table : Control
{
    [Export] public Deck Deck { get; set; }
    public Card PreviousCard { get; set; }
    public Card CurrentCard { get; set; }

    public Array<Player> players = new Array<Player>();

    public Player currentPlayer;
    public override void _Ready()
    {
        base._Ready();
        Deck.Initialize();
        Deck.Shuffle();
        PreviousCard = Deck.Take();
        PreviousCard.GlobalPosition = new Vector2(360, 640);
    }


    public void PlaceCard(Card placedCard)
    {
        CurrentCard = placedCard;
    }



    public Card TakePrevious()
    {
        Card previous = PreviousCard;
        PreviousCard = CurrentCard;
        return previous;
    }



    public Card DrawFromDeck()
    {
        PreviousCard = CurrentCard;

        // TODO: can return null
        return Deck.Take();
    }

}
