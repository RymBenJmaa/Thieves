using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MultiplayerStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void multiStart()
    {


        SceneManager.LoadScene("MultiplayerLobby");
        //   GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>().mort = false;
    }
}
