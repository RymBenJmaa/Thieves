using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateScript : MonoBehaviour {
    public float speed = 0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("singlePlayer").GetComponent<PlayerScript>().mort == true)
        {
            this.enabled = false;
        }
        this.transform.Translate(new Vector2(speed, 0));
    }
}
