
using System;
namespace AssemblyCSharp
{
		public class Card : Photon.MonoBehaviour
		{
			private string name; //Cards name
			private string type; //Land, Creature, Instant, Sorcery
			//private string status; //the cards status on the stack
			//private int color_Cost;
			//private int colorless_Cost;
			//private int damage;
			//private int defense;
			//private string effectTag;

			public Card ()
			{
			
			}

			public string getName()
			{
				return name;
			}
			
			public string getType()
			{
				return type;
			}

			/*
			
			public string getStatus()
			{
				return status;
			}
			
			public void plusXplusY(int x, int y){
				this.damage = this.damage + x;
				this.defense = this.defense + y;
			}

			public string getEffect(){
				return effectTag;
			}

			public int attack(){
				return damage;
			}
			*/
		}
}

