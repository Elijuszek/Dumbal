using System.Collections.Generic;
using System.Linq;
namespace Dumbal;

public partial class Deck : Control
{
    public Card LastCard { get; set; }
    private Array<Card> cards;
    private PackedScene cardScene = ResourceLoader.Load<PackedScene>("res://Scenes/Cards/Card.tscn");
    public override void _Ready()
    {
        base._Ready();
        cards = new Array<Card>();
    }

    public void Initialize()
    {
        for (int i = 1; i <= 13; i++)
        {
            cards.Add(NewCard(CardType.Hearts, (CardValue)i));
            cards.Add(NewCard(CardType.Diamonds, (CardValue)i));
            cards.Add(NewCard(CardType.Spades, (CardValue)i));
            cards.Add(NewCard(CardType.Clubs, (CardValue)i));
        }
        cards.Add(NewCard(CardType.Joker, CardValue.Joker));
        cards.Add(NewCard(CardType.Joker, CardValue.Joker));
    }

    public Card Take()
    {
        Card card = cards.Last();
        cards.RemoveAt(cards.Count-1);
        return card;
    }

    private Card NewCard(CardType type, CardValue value)
    {
        Card newCard = cardScene.Instantiate<Card>();
        newCard.Type = type;
        newCard.Value = value;
        return newCard;
    }

    public void Shuffle() => cards.Shuffle();
}