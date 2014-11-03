
using System.Collections.Generic;
namespace AssemblyCSharp
{
		public class Deck
		{
			private List<Card> playerDeck;
			private List<Card> playerGrave;
			private List<Card> playerExile;

			
			public Deck ()
			{
				playerDeck = new List<Card> ();
				playerGrave = new List<Card> ();
				playerExile = new List<Card> ();
			}

			public Deck(List<Card> premade)
			{
				playerDeck = premade;
				playerGrave = new List<Card>();
				playerExile = new List<Card>();
			}
			
			public void shuffle(){

			}

			public Card draw(){
				Card theDraw = playerDeck [0];
				playerDeck.RemoveAt(0);
				return theDraw;
				
			}

			public void toGrave(Card cardObject){
				playerGrave.Add(cardObject);

			}

			public void toExile(Card cardObject){
				playerExile.Add(cardObject);
			}

			public void toDeckBottom(Card cardObject){
				playerDeck.Add(cardObject)
			}
			
		}
}

