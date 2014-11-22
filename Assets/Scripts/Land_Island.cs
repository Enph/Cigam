using UnityEngine;
using System.Collections;

public class Land_Island : Photon.MonoBehaviour {

	public int cardNum;
	public string cardName;	
	public Texture front;
	public Texture background;
	public Texture backgroundTapped;


	public int state = 0;
	string tag;


	Vector3 axis = new Vector3(0f,1f,0f);



	// Use this for initialization
	void Start () {


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
		this.transform.RotateAround(transform.position,axis,90);
	}
	
	public void untapCard(){
		renderer.enabled = true;
		this.transform.RotateAround(transform.position,axis,-90);
	}
	
	public void setCardName(string name){
		this.cardName=name;
	}

}
