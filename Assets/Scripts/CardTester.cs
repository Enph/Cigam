﻿using UnityEngine;
using System.Collections;

public class CardTester : Photon.MonoBehaviour {
	public int state = 0;
	CardManager cardMan;
	// Use this for initialization
	void Start () {
		cardMan = GetComponent<CardManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		state++;
		
		switch(state){
			case 1:
				cardMan.showBack();
				break;
			case 2:
				cardMan.showFront();
				state = 0;
				break;
			/*case 3:
				cardMan.hideCard();
				state = 0;
				break;*/
				
		}
	}
}
