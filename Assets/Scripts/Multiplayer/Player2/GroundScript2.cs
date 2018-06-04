using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript2 : MonoBehaviour {

    private Transform myTf;
    public GameObject g1,g2,g3,g4,g5;
    GameObject[] spawnGround;
    GameObject currentGround;
    int index, intensNum = 0;
    private bool next = false;
    
    public float speed=0.1f;
    private Vector3 startPosition;


    GameObject test;
    void Start()
    {
       speed = 0.1f;
        spawnGround   = new GameObject[5];
        myTf = this.GetComponent<Transform>();
        spawnGround[0]=g1;
        spawnGround[1] = g2;
        spawnGround[2] = g3;
        spawnGround[3] = g4;
        spawnGround[4] = g5;
        GameObject[]  coins =GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject item in coins)
        {
           item.GetComponent<SpriteRenderer>().enabled = true;
        }
     
    }

    void Update()
    {
       // GroundScript.speed = 0.1f;
        if (GameObject.Find("Boost").GetComponent<Boost>().boosted == true)
        {
            speed = 0.3f;

        }else
        {
            speed = 0.1f;
        }
      
        if (GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerScript2>().mort == true)
        {
            this.enabled = false;
          
        }

        this.transform.Translate(new Vector2(speed, 0));
     /*   Transform t = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        t.position = new Vector3(myTf.position.x + 5.80f, 0, -10f);*/
        //if (this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground2")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground3"))||this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground4")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground5")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground6"))|| this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground7")) )
        // {
        if ((myTf.position.x > -2.71f + intensNum * 39.69f) )
            {

                index = Random.Range(0, 5);
              //  print(index);
                currentGround = spawnGround[index];
              
                   test = Instantiate(currentGround, new Vector2(41.7f + (intensNum * 41f), -0.36f), new Quaternion());
                 intensNum = intensNum + 1;
                  test.name = "ground" + intensNum;
        }
        //  }
        if (myTf.position.x > 27.56f + intensNum * 39.69f)
        {
            print("entred destroy zone");
            if (intensNum == 1)
            {
                Destroy((GameObject.Find("g0")));
            }
            else if (intensNum > 1)
            {

                Destroy((GameObject.Find("ground" + (intensNum - 1))));
            }
        }
        /*
          if (myTf.position.x < -38f)
          {
              Destroy(this.gameObject);
          }
        */

    }

}
