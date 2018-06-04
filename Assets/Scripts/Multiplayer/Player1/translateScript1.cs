using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateScript1 : MonoBehaviour {
    public float speed = 0.1f;
    // Use this for initialization
    void Start () {
        /*  GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript1>().mort = false;
          GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerScript2>().mort = false;*/
        StartCoroutine(Example());
       
    }
	
	// Update is called once per frame
	void Update () {
    /*    if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript1>().mort == true || GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerScript2>().mort == true)
        {
            this.enabled = false;
        }*/
        this.transform.Translate(new Vector2(speed, 0));
    }
    IEnumerator Example()
    {
      //  this.enabled = true;
        yield return new WaitForSeconds(5);
       this.enabled = true;
    }
}
