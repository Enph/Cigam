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
		
	}
	
}
