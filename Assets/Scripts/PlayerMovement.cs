using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PhotonView[] photonViews;

    private PhotonView PhotonView;
    private GameObject[] players;   
	// Use this for initialization
	void Start () {
       photonViews = Object.FindObjectsOfType<PhotonView>();
        foreach (var item in (PhotonNetwork.playerList))
        {
            Debug.Log(item.TagObject + "dzdzdz");                     
           // PhotonView.Find(item.ID).gameObject.GetComponent<Transform>();
            //Debug.Log(PhotonView.Find(item.ID).gameObject.GetComponent<Transform>());
        }
        foreach (var view in photonViews)
        {
            var player = view.owner;
            //Objects in the scene don't have an owner, its means view.owner will be null

            Debug.Log(view.gameObject + "aaaaaaaaaaaaaaaaaa");
           // var playerPrefabObject = view.gameObject;            
            
        }

    }

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update () {
        if(PhotonView.isMine)
        CheckInput();

       
    }
    private void CheckInput()
    {
        float moveSpeed = 100f;
        float rotateSpeed = 500f;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += transform.forward * (vertical * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontal * rotateSpeed * Time.deltaTime, 0));
    }
   
}
