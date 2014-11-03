
using System;
namespace AssemblyCSharp
{
		public class Card
		{
			private string name;
			private int damage;
			private int defense;
			private string effectTag;
			private string status;

			public Card ()
			{
			}

			public void plusXplusY(int x, int y){
				this.damage = this.damage + x;
				this.defense = this.defense + y;
			}

			public string getEffect(){
				return effectTag;
			}

			public string getStatus(){
				return status;
			}

			public int attack(){
				return damage;
			}
		}
}

