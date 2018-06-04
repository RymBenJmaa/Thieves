using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost2 : MonoBehaviour {
    public  bool boosted = false;
    float runTime = 0.2f;
    public GameObject player;
     public static bool boostme = false;
    float timer = 0.0f;
    //  public GameObject player;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(boostme == true)
        {
            GameObject[] obst = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (var item in obst)
            {

                item.GetComponent<PolygonCollider2D>().enabled = false;

            }
            GameObject.FindGameObjectWithTag("player2").transform.GetChild(0).GetComponent<TrailRenderer>().enabled = true;
         
        }
        else
        {
            GameObject[] obst = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (var item in obst)
            {

                item.GetComponent<PolygonCollider2D>().enabled = true;

            }
            GameObject.FindGameObjectWithTag("player2").transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
         
        }




    }
    public void booost()
    {
        boostme = true;
   
      
            boosted = true;
           
       
            StartCoroutine(Example());

        /*
        GameObject[] obst = GameObject.FindGameObjectsWithTag("obstacle");
        //    GameObject[] obsts = GameObject.FindGameObjectsWithTag("obst1");


        //  Debug.Log((obsts == null ? "true  " : "false") + "obsts");
        /*  Debug.Log(obsts[0].name + " ");
             Debug.Log(obsts[1].name + " ");
               Debug.Log(obsts[2].name + " ");
        //   Debug.Log(obsts[3].name );


        Debug.Log(timer);
        Debug.Log(runTime);
        while (timer < runTime)
        {
            boosted = true;
            GameObject[] g = GameObject.FindGameObjectsWithTag("ground");
            
            if (g != null)
            {
                foreach (var item in g)
                {
                    item.GetComponent<GroundScript>().speed = 0.3f;
                    Debug.Log(item.GetComponent<GroundScript>().speed + " in while");
                }
            }
            // player.GetComponent<ColliderRefresh>().iStrigger = true;

              foreach (var item in obst)
               {
                if (item.GetComponent<PolygonCollider2D>().enabled == true)
                 {  item.GetComponent<PolygonCollider2D>().enabled = false;
                   Debug.Log(item.GetComponent<PolygonCollider2D>().enabled + "  in while");
               }
        }
       
            timer =timer+ Time.deltaTime;
          
        }
      
        StartCoroutine(Example());
        boosted = false;
        if (obst != null)
        {
            foreach (var item in obst)
            {
                if (item.GetComponent<PolygonCollider2D>().enabled == false)
                { item.GetComponent<PolygonCollider2D>().enabled = true; 
                Debug.Log(item.GetComponent<PolygonCollider2D>().enabled + "  after while");
                }
            }
        }
    /   if (obsts != null)
        {
            foreach (var item in obsts)
            {
                item.GetComponent<PolygonCollider2D>().enabled = true;
                Debug.Log(item.GetComponent<PolygonCollider2D>().enabled + "obsts after while");
            }
            //     GameObject.FindWithTag("player").GetComponent<ColliderRefresh>().iStrigger = false;
        }*/


    }
    IEnumerator Example()
    {/*
        GameObject[] g = GameObject.FindGameObjectsWithTag("ground");

        if (g != null)
        {
            foreach (var item in g)
            {
                item.GetComponent<GroundScript>().speed = 0.3f;
                Debug.Log(item.GetComponent<GroundScript>().speed + " in while");
            }
        }*/
        yield return new WaitForSeconds(2f);
        boosted = false;
        boostme = false;

    }
}
