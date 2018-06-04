using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript2 : Photon.MonoBehaviour
{
    Rigidbody2D myRB;
    Animator myAnimator;
    public float speed;
    public static int score = 0;
    public Sprite deadSprite;
    public  bool mort = false;
    GameObject btnHome;
    public Transform SpawnPos;
  //  public GameObject obstacle;
    int jumpCount = 0;
    bool grounded = true, candobulejump=true;

    private Vector2 secondPressPos;
    private Vector3 currentSwipe;
    private Vector2 firstPressPos;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        myRB = this.GetComponent<Rigidbody2D>();
        myAnimator = this.GetComponent<Animator>();
        btnHome = GameObject.FindGameObjectWithTag("Home");

        score = 0;
        this.transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
        //  InvokeRepeating("spawnObslactles", 0.1f, 2f);
    }
    IEnumerator wait(float i)
    {
        print(Time.time);
        yield return new WaitForSeconds(i);
        print(Time.time);
    }
    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            GameObject.Find("Booster").GetComponent<Boost1>().player = this.player;
            if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript1>().mort == true)
            {
                GameObject.FindGameObjectWithTag("win").SetActive(true);
            }
        }
        myAnimator.SetBool("Sliding", false);
        if (myRB.position.y <= -2.6f)
        { grounded = true;
            myAnimator.SetBool("Jumping", false);
        }
        Swipe();
   /*if (Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            jump();
        }*/
        if (myRB.position.y == -2.862f)
        {
            myAnimator.SetBool("Running", true);
            myAnimator.SetBool("Jumping", false);
          //  myAnimator.SetBool("Sliding", false);
           
        }
            /*    this.enabled = false;
                wait(5f);
                this.enabled = true;
                */


            //-3.136632
            if (myRB.position.y < -3.42f || myRB.position.y > 3.52f)
        {
            mort = true;
         
            print("lfou9 louta");
            //  myAnimator.SetBool("dead", true);
            myAnimator.SetBool("Tripping", true);
            if (PlayerPrefs.GetInt("BestScore") < score)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
            this.enabled = false;
            GameObject.FindGameObjectWithTag("lose").SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (Boost2.boostme == false)
        {


            if ((col.gameObject.tag.Equals("obstacle") || col.gameObject.tag.Equals("obst1")) && GameObject.Find("Booster").GetComponent<Boost>().boosted == false)
            {
                /*    myAnimator.SetBool("dead", true);*/
                if (PlayerPrefs.GetInt("BestScore") < score)
                {
                    PlayerPrefs.SetInt("BestScore", score);
                }
                mort = true;
                print("obstacle mort!");
                GameObject.FindGameObjectWithTag("lose").SetActive(true);
                this.enabled = false;
                btnHome.SetActive(true);
                myAnimator.SetBool("Tripping", true);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        score = score + 1;
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
       // print(score);
    }

    public void goHome()
    {
        SceneManager.LoadScene("Menu2");
    }
   /* void spawnObslactles()
    {
        Instantiate(obstacle, SpawnPos.position, SpawnPos.rotation);
    }
   */
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 &&  currentSwipe.x > -0.5f  &&currentSwipe.x < 0.5f)
             {
                    print("up swipe");
                    Debug.Log("up swipe");
                    if(candobulejump ||grounded)
                    jump();
                    myAnimator.SetBool("Sliding", false);
                    //   yield return new WaitForSeconds(0.1f);
                }
                //swipe Sliding
                if (currentSwipe.y < 0  && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
             {
                    print("Sliding swipe");
                    Debug.Log("Sliding swipe");
                    swipeSliding();
                  
                 
                    //   yield return new WaitForSeconds(0.1f);
                }
                //swipe left
                if (currentSwipe.x < 0 &&  currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    print("left swipe");
                    Debug.Log("left swipe");
                 /*   myAnimator.SetBool("Sliding", true);
                    myRB.velocity = Vector2.left * speed * 5;
                    jumpCount = jumpCount + 1;
                    print(jumpCount + "clicks");
                    candobulejump = true;
                    grounded = false;*/
                }
                //swipe right
                if (currentSwipe.x > 0  && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                 /*   print("right swipe");
                    Debug.Log("right swipe");
                    myAnimator.SetBool("Sliding", true);
                    myRB.velocity = Vector2.right * speed * 5;
                    jumpCount = jumpCount + 1;
                    print(jumpCount + "clicks");
                    candobulejump = true;
                    grounded = false;*/
                }
            }
        }
    }
    private void swipeSliding()
    {
        myAnimator.SetBool("Sliding", true);
        myRB.velocity = Vector2.down * speed*5;
        jumpCount = jumpCount + 1;
      
        candobulejump = true;
        grounded = false;
    }

    private void jump()
    {
        myAnimator.SetBool("Jumping", true);
        myAnimator.SetBool("Sliding", false);
        myRB.velocity = Vector2.up * speed*1.5f;
        jumpCount = jumpCount + 1;
      
        candobulejump = false;
        grounded = false;
    }
}
