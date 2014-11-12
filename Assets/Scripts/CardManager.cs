using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {
	public int cardNum;
	
	public string cardName;
	
	public Texture[] fronts;
	
	public string[] Names = new string[3]{"nissaworldwaker","plains","oreskosswiftclaw"};
	
	public Texture background;
	
	Vector3 axis = new Vector3(0f,1f,0f);

	public void showBack(){
		renderer.enabled = true;
		renderer.material.mainTexture = background;
	}

	public void showFront(){
		renderer.enabled = true;
		for(int i = 0; i < Names.Length;i++)
		{
			if(Names[i]==cardName)
			{
				cardNum = i;
			}
		}
		renderer.material.mainTexture = fronts[cardNum];
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
	
	// Use this for initialization
	void Start () {
		showFront();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
