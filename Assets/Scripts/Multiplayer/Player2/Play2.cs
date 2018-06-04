using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Play2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
    }
    public void play()
    {
      /*  if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }*/
        SceneManager.LoadScene("LevelOneSingle");
     //   GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>().mort = false;
    }
}
