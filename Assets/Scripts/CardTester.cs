﻿using UnityEngine;
using System.Collections;

public class CardTester : Photon.MonoBehaviour {

	public int state = 0;
	CardManager cardMan = new CardManager();
	string tag;

	// Use this for initialization
	void Start () {
		cardMan = GetComponent<CardManager>();
		cardMan.cardName = "nissaworldwaker";
	}
	
	// Update is called once per frame
	void Update () {
		faceUpDown();
	}	
    
	void OnPhotonSerialView(PhotonStream stream , PhotonMessageInfo info)
	{
		//NEED TO FIX THIS SO THEY UPDATE IN REAL TIME
	}
	
	void OnMouseUp(){
		state++;
		switch(state){
<<<<<<< HEAD
		case 1:
			tag = "Up";
			break;
		case 2:
			tag = "Down";
			state = 0;
			break;
=======
			case 1:
				cardMan.tapCard();
				//cardMan.showBack();
				cardMan.showFront();
				break;
			case 2:
				cardMan.untapCard();
				cardMan.showFront();
				state = 0;
				break;
>>>>>>> origin/master
		}
	}
	
	void faceUpDown(){
		if(tag == "Up"){
			cardMan.showFront();
			//Debug.Log("Up");
		}
		if(tag == "Down"){
			cardMan.showBack();
			//Debug.Log("Down");
		}

	}


}
