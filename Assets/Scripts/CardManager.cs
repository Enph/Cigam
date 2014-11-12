using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {
	public int cardNum;
	
	public Texture[] fronts;
	
	public Texture background;

	public void showBack(){
		renderer.enabled = true;
		renderer.material.mainTexture = background;
	}

	public void showFront(){
		renderer.enabled = true;
		renderer.material.mainTexture = fronts[cardNum];
	}

	public void hideCard(){
		renderer.enabled = false;
	}

	// Use this for initialization
	void Start () {
		showFront();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
