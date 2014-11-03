
using System.Collections.Generic;
namespace AssemblyCSharp
{
		public class Deck
		{
			private List<Card> playerDeck;
			private List<Card> playerGrave;
			private List<Card> playerExile;
			private int deckSize;
			private int numLeft;
			private int topCard;
			
			public Deck (int size)
			{
				this.deckSize = size;
				this.numLeft = deckSize;
			}
			
			public void shuffle(){

			}

			public Card draw(){
				

			}

			public void toGrave(Card cardObject){

			}

			public void toExile(Card cardObject){

			}
			
		}
}

