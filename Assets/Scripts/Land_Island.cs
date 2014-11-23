using UnityEngine;
using System.Collections;

public class Land_Island : Photon.MonoBehaviour {

	public int cardNum;
	public string cardName;	
	public Texture front;
	public Texture background;
	public Texture tapped;
	public Texture currentText;
	

	public int state = 0;
	string tag;


	Vector3 axis = new Vector3(0f,1f,0f);



	// Use this for initialization
	void Start () {
		tag = "untap";

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
		//if mouse is clicked, tap or untap card
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
<<<<<<< HEAD
		currentText = renderer.material.mainTexture; //if mouse is hovered over set currentText to the maintexure (usally front of the card)
		Debug.Log ("I am selected");
=======
		currentText = renderer.material.mainTexture;
		//Debug.Log ("I am selected");
>>>>>>> origin/master
	}
	
	void OnMouseExit(){
		currentText = null; //if mouse leaves object set currentText to null
	}
	

}
