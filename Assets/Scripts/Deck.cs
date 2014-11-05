
using System.Collections.Generic;
using System;
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
				Random rand = new Random();
				Card temp = new Card();
				int index;
				for(int i = 0; i < playerDeck.Count - 1; i++){ 
				/*found online, not best best algo for shuffling
				  because Random() sucks, but it'll do*/
					index = rand.Next (0, playerDeck.Count);
					temp = playerDeck[i];
					playerDeck[i] = playerDeck[index];
					playerDeck[index] = temp;
				}
				

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
				playerDeck.Add(cardObject);
			}
			
		}
}

