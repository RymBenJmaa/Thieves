using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollingBg : MonoBehaviour {
    private Transform myTf;
    public GameObject background;
    private bool next = false;
    public float speed;

    bool start = false;
    private Vector3 startPosition;

    void Start()
    {
        myTf = this.GetComponent<Transform>();
      /*  GameObject.Find("Full Background").GetComponent<ScrollingBg>().enabled = false;
        GameObject.Find("Back Background").GetComponent<FrontbackgroundScrolling>().enabled = false;
        GameObject.Find("Front Background").GetComponent<FrontbackgroundScrolling>().enabled = false;*/

    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>().mort == true)
        {
            this.enabled = false;
        }
      /* if (start == true)
        {*/
            this.transform.Translate(new Vector2(speed, 0));
            if (myTf.position.x < 15.12f && !next)
            {
              
              GameObject test=  Instantiate(background, new Vector2(55f,15f), new Quaternion());
            test.tag = "clone";
            
            next = true;

            }
            if (myTf.position.x < -26f)
            {
                Destroy(this.gameObject);
            }
       // }

    }
    public void Play()
    {
        Destroy(GameObject.Find("Play"));
        Destroy(GameObject.Find("Title"));
      /*  GameObject.Find("Full Background").GetComponent<ScrollingBg>().enabled = true;
        GameObject.Find("Back Background").GetComponent<FrontbackgroundScrolling>().enabled = true;
        GameObject.Find("Front Background").GetComponent<FrontbackgroundScrolling>().enabled = true;*/
        start = true;
    }
}