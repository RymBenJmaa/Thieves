using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounds : MonoBehaviour {
    private Transform myTf;
    private bool next = false;
    public float speed;


    void Start()
    {

        myTf = this.GetComponent<Transform>();

    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>().mort == true)
        {
            this.enabled = false;
        }

        this.transform.Translate(new Vector2(-speed, 0));


    }
}
