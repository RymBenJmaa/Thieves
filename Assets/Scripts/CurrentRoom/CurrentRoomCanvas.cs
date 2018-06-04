using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRoomCanvas : MonoBehaviour {

    private PhotonView PhotonView;
    private GameObject btnlocalg;
    private Button btnglobal;
    private Button btnlocal;
    public GameObject[] allplayerbtn;
    public Sprite non;
    public Sprite oui;
    private IEnumerator coroutine;
    public Button BtnStart;
    public static int NbPlayerReady = 0;
    public int inx = 0;
    public static List<string> list = new List<string>();
    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    public void OnClickStartSync()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void OnClickStartDelayed()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;
        PhotonNetwork.LoadLevel(1);
    }
    

    public void OnReadyButton(PhotonPlayer photonPlayer)
    { 
        PhotonView.RPC("RPC_PlayerGetReady", PhotonTargets.AllBuffered, PhotonNetwork.player);     
    }

    public void OnReadyState(bool k)
    {
        if (k)
        {           
            PhotonView.RPC("RPC_ReadyStateLeave", PhotonTargets.AllBuffered, PhotonNetwork.player);
        }  

    }

    [PunRPC]
    private void RPC_PlayerGetReady(PhotonPlayer photonPlayer)
    {       
        Debug.Log(photonPlayer.NickName + " Is Ready");
        btnlocalg = GameObject.Find(photonPlayer.ID.ToString());
        btnlocal = btnlocalg.GetComponent<Button>();
        btnlocal.interactable = true;
        btnlocal.GetComponent<Image>().sprite = oui;
        btnlocal.GetComponent<Image>().color = Color.blue;
        btnlocal.GetComponentInChildren<Text>().text = "Ready";
        photonPlayer.TagObject = photonPlayer.NickName;
        allplayerbtn = GameObject.FindGameObjectsWithTag("aa");
        NbPlayerReady++;
        Debug.Log(NbPlayerReady+ "NbPlayerReady");      
        if (PhotonNetwork.isMasterClient)
        {
            if (NbPlayerReady == PhotonNetwork.room.MaxPlayers)
            {
                BtnStart.gameObject.SetActive(true);
            }
        }
                     
    }


    [PunRPC]
    private void RPC_ReadyStateJoin(PhotonPlayer photonPlayer)
    {
        allplayerbtn = GameObject.FindGameObjectsWithTag("aa");
        btnlocalg = GameObject.Find(PhotonNetwork.player.ID.ToString());


  
         if (PhotonNetwork.room.PlayerCount == PhotonNetwork.room.MaxPlayers)
        {
            foreach (GameObject t in allplayerbtn)
            {
                btnglobal = t.GetComponent<Button>();
                btnglobal.GetComponentInChildren<Text>().text = "Not Ready";
            }
            btnlocal = btnlocalg.GetComponent<Button>();
            btnlocal.interactable = true;
            btnlocal.GetComponent<Image>().sprite = oui;
            btnlocal.GetComponent<Image>().color = Color.white;
            btnlocal.GetComponentInChildren<Text>().text = "Join";
            Debug.Log("full room");
           
        }
       
    }

    [PunRPC]
    private void RPC_ReadyStateLeave(PhotonPlayer photonPlayer)
    {      
        allplayerbtn = GameObject.FindGameObjectsWithTag("aa");
        btnlocalg = GameObject.Find(PhotonNetwork.player.ID.ToString());
       

      
            foreach (GameObject t in allplayerbtn)
            {
                btnglobal = t.GetComponent<Button>();
                btnglobal.interactable = false;
                btnglobal.GetComponentInChildren<Text>().text = "...";
                btnglobal.GetComponent<Image>().sprite = non;
            }
            Debug.Log("NOT full room");
        NbPlayerReady = 0;
    }
  
    public void OnJoinedRoom()
    {

        for (int i = 0; i < PhotonNetwork.room.MaxPlayers; i++)
        {
            list.Add("lou");
        }
        Debug.Log("Joined Room");
        StartCoroutine(WaitAndPrint());
    }

    public void OnLeftRoom()
    {       
        Debug.Log("leaving");
    }
    private IEnumerator WaitAndPrint()
    {             
        yield return new WaitForSeconds(0.1f);
        PhotonView.RPC("RPC_ReadyStateJoin", PhotonTargets.AllBuffered, PhotonNetwork.player);
    }
  

}
