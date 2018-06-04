using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBackground : MonoBehaviour
{
    private Transform myTf;
    public GameObject background;
    private bool next = false;
    public float speed;
    // Use this for initialization
    void Start()
    {
        myTf = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>().mort == true)
        {
            this.enabled = false;
        }
        this.transform.Translate(new Vector2(speed, 0));
        if (myTf.position.x < -6.361f && !next)
        {
          GameObject test=  Instantiate(background, new Vector2(14.361f, -0.5250149f), new Quaternion());
            test.tag = "clone";
            next = true;

        }
        if (myTf.position.x < -26f)
        {
            Destroy(this.gameObject);
        }




    }
}

