using UnityEngine;
using System.Collections;

public class DebugDev : MonoBehaviour {
	
	
	public NetworkManager[] networkManager;
	public VectorManager[] vectorManager;
	public GameManager[] gameManager;
	
	public bool showDebugMenu = false;
	
	// Use this for initialization
	void Start () {
		
		networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		vectorManager = GameObject.FindObjectsOfType<VectorManager>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		
		if(showDebugMenu == true)
		{
			
			if (GUI.Button (new Rect (10,300,200,50), "Whats my name?")) 
			{
				Debug.Log (PhotonNetwork.playerName);
			}
		}
	}
	
}
