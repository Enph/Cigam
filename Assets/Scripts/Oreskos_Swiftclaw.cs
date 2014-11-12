using UnityEngine;
using System.Collections;

public class Oreskos_Swiftclaw : Photon.MonoBehaviour {

	public int state = 0;
	CardManager cardMan;
	// Use this for initialization
	void Start () {
		cardMan = GetComponent<CardManager>();
		cardMan.cardName = "oreskosswiftclaw";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseUp(){
		state++;
		
		switch(state){
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
		}
	}
}
