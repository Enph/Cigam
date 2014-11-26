using UnityEngine;
using System.Collections;

public class Creature_Oreskosswiftclaw : MonoBehaviour,I_Creature {

	public int cardNum;
	public string cardName;	
	public Texture front;
	public Texture background;
	public Texture tapped;
	public Texture currentText;
	public bool summoning_sickness = true;
	public bool flying = false;
	public bool intimidate = false;
	public bool haste = false;
	public bool vigilance = false;
	public bool lifelink = false;
	public int power = 3;
	public int toughness = 1;
	public int no_color_mana = 1;
	public int white_mana = 1;
	public int red_mana = 0;
	public int black_mana = 0;
	public int blue_mana = 0;
	public int green_mana = 0;
	
	public int state = 0;
	string tag;
	
	
	Vector3 axis = new Vector3(0f,1f,0f);
	
	
	
	// Use this for initialization
	void Start () {
		tag = "untap";
		this.cardName = "Creature_Oreskosswiftclaw";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void showBack(){
		renderer.enabled = true;
		renderer.material.mainTexture = background;
	}
	
	public void showFront(){
		renderer.enabled = true;
		renderer.material.mainTexture = front;
	}
	
	public void hideCard(){
		renderer.enabled = false;
	}
	
	public void tapCard(){
		renderer.enabled = true;
		this.transform.RotateAround(transform.position,axis, 90);
	}
	
	public void untapCard(){
		renderer.enabled = true;
		this.transform.RotateAround(transform.position,axis, -90);
		
	}
	
	public void setCardName(string name){
		this.cardName=name;
	}
	
	void OnMouseUp(){
		
		switch(state){
		case 0:
			tapCard ();
			state = 1;
			break;
		case 1:	
			untapCard ();
			state = 0;
			break;
		}
		
	}
	
	void OnMouseOver(){
		currentText = renderer.material.mainTexture;
		Debug.Log ("I am selected");
	}
	
	void OnMouseExit(){
		currentText = null;
	}
	
	public string getName(){
		return cardName;
	}
	public int getPower(){
		return power;
	}
	public int getToughness(){
		return toughness;
	}
	public int getCMC(){
		return no_color_mana+red_mana+white_mana+blue_mana+black_mana+green_mana;
	}
	public int getNoColorMana(){
		return no_color_mana;
	}
	public int getRedMana(){
		return red_mana;
	}
	public int getGreenMana(){
		return green_mana;
	}
	public int getBlueMana(){
		return blue_mana;
	}
	public int getBlackMana(){
		return black_mana;
	}
	public int getWhiteMana(){
		return white_mana;
	}
	public bool isSummoningSickness(){
		return summoning_sickness;
	}
	public bool isFlying(){
		return flying;
	}
	public bool isIntimidate(){
		return intimidate;
	}
	public bool isHaste(){
		return haste;
	}
	public bool isLifelink(){
		return lifelink;
	}
	public bool isVigilance(){
		return vigilance;
	}
	public void Die(){
		Destroy(gameObject);
	}
	
}
