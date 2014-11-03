
using System;
namespace AssemblyCSharp
{
		public class Deck
		{
			private Card[] playerDeck;
			private Card[] playerGrave;
			private Card[] playerExile;
			private int deckSize;
			private int numLeft;
			private int topCard;
			
			public Deck (int size)
			{
				this.deckSize = size;
				this.numLeft = deckSize;
				this.topCard = 0;
				this.playerDeck = new Card[deckSize];
				this.playerGrave = new Card[deckSize];
				this.playerExile = new Card[deckSize];
			}
			
			public void shuffle(){

			}

			public Card draw(){
				Card theDraw = playerDeck [topCard];
				topCard ++;
				return theDraw;
				

			}

			public void toGrave(Card cardObject){

			}

			public void toExile(Card cardObject){

			}
			
		}
}

