using UnityEngine;
using System.Collections;

public class DebugDev : Photon.MonoBehaviour {
	
	
	public NetworkManager[] networkManager;
	public VectorManager[] vectorManager;
	public GameManager[] gameManager;
	public Player[] player;
	
	public bool showDebugMenu = false;
	
	// Use this for initialization
	void Start () {
		
		networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		vectorManager = GameObject.FindObjectsOfType<VectorManager>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();

		if(GameObject.FindObjectsOfType<Player>() != null)
			player = GameObject.FindObjectsOfType<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	
	void OnGUI()
	{
		
		if(showDebugMenu == true)
		{
			
			if (GUI.Button (new Rect (10,300,200,50), "reduce HP")) 
			{
				//player[0].playerHealth--;
				player[0].TakeDamage(1);
				Debug.Log (player[0].playerHealth);
			}

			if (GUI.Button (new Rect (10,350,200,50), "reduce HP Op")) 
			{
				//player[0].playerHealth--;
				Debug.Log (player[1].playerHealth);
			}
		}
	}
	
}
