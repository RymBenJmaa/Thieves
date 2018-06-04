using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSparkeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameSparks.Core.GS.GameSparksAvailable += OnGameSparksConnected;
    }
    private void OnGameSparksConnected(bool _isConnected)
    {
        if (_isConnected)
        {
            Debug.Log("GameSparks Connected...");
        }
        else
        {
            Debug.Log("GameSparks Not Connected...");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
