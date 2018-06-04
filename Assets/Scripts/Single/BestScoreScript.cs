using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
