using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript1 : Photon.MonoBehaviour {

    private Transform myTf;
    public GameObject g1,g2,g3,g4,g5;
    GameObject[] spawnGround;
    GameObject currentGround,p1,p2;
    int index, intensNum = 0;
    private bool next = false;
    private PhotonView photonView;
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
        spawnGround[5] = g3;
        spawnGround[6] = g1;
        spawnGround[7] = g2;
        spawnGround[8] = g5;
        spawnGround[9] = g1;
        spawnGround[10] = g3;
        spawnGround[11] = g4;
        spawnGround[12] = g2;
        spawnGround[13] = g1;
        spawnGround[14] = g2;
        spawnGround[15] = g5;
        spawnGround[16] = g4;
        spawnGround[17] = g1;
        spawnGround[18] = g4;
        spawnGround[19] = g5;

        GameObject[]  coins =GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject item in coins)
        {
           item.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (PhotonNetwork.player.ID == 1)
        {
            p1 = GameObject.Find("Player1");
            p2 = GameObject.Find("Player2(Clone)");
        }
        else
        {
            p1 = GameObject.Find("Player2");
            p2 = GameObject.Find("Player(Clone)");
        }

    }
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
       // GroundScript.speed = 0.1f;

     
            speed = 0.1f;
        
      /*
        if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript1>().mort == true||
            GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerScript1>().mort == true)
        {
            this.enabled = false;
          
        }*/

        this.transform.Translate(new Vector2(speed, 0));

        Transform t = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        //  t.position = new Vector3(myTf.position.x + 5.80f, 0, -10f);
        t.transform.Translate(new Vector2(speed/2, 0));

        //if (this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground2")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground3"))||this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground4")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground5")) || this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground6"))|| this.GetComponent<GameObject>().Equals(GameObject.FindGameObjectWithTag("ground7")) )
        // {
        if ((myTf.position.x > -2.71f + intensNum * 39.69f) )
            {
            index = 0;
            if (index == 18)
            { index = 0; }

              //  print(index);
                currentGround = spawnGround[index];
              
                   test = Instantiate(currentGround, new Vector2(41.7f + (intensNum * 41f), -0.36f), new Quaternion());
                 intensNum = intensNum + 1;
                  test.name = "ground" + intensNum;
            index = index + 1;
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
