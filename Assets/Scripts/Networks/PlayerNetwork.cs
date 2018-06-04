using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    private PhotonView PhotonView;
    private int PlayersInGame = 0;
    public string PlayerName { get; set; }
   
    private ExitGames.Client.Photon.Hashtable m_playerCustomProperties = new ExitGames.Client.Photon.Hashtable();
    private Coroutine m_pingCoroutine;
    

    private void Awake()
    {
        Instance = this;
        PhotonView = GetComponent<PhotonView>();
        PlayerName = "Player#" + Random.Range(1000, 9999);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelOneMultiplayer")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NonMasterLoadedGame();
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
    }

    [PunRPC]
    public void Ajout()
    {
        System.Random rnd = new System.Random();
        int r = rnd.Next(CurrentRoomCanvas.list.Count);
        string hh = CurrentRoomCanvas.list[r];
        Debug.Log(hh+CurrentRoomCanvas.list.Count);
        CurrentRoomCanvas.list.RemoveAt(r);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {

        PhotonNetwork.LoadLevel(1);

    }

    [PunRPC]
    private void RPC_LoadedGameScene(PhotonPlayer photonPlayer)
    {
        PhotonView.RPC("Ajout", PhotonTargets.AllBuffered);
        PlayersInGame++;
        Debug.Log(photonPlayer.NickName + " is Ready");
        Debug.Log(PlayersInGame+"after");     
        if (PlayersInGame == PhotonNetwork.playerList.Length)
        {
            print("All players are in the game scene.");
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }




    private IEnumerator C_SetPing()
    {
        while (PhotonNetwork.connected)
        {
            m_playerCustomProperties["Ping"] = PhotonNetwork.GetPing();
            PhotonNetwork.player.SetCustomProperties(m_playerCustomProperties);

            yield return new WaitForSeconds(5f);
        }

        yield break;
    }


    //When connected to the master server (photon).
    private void OnConnectedToMaster()
    {
        if (m_pingCoroutine != null)
            StopCoroutine(m_pingCoroutine);
        m_pingCoroutine = StartCoroutine(C_SetPing());
    }
    [PunRPC]
    private void RPC_CreatePlayer()
    {
        GameObject obj, obj2;

        //float randomValue = Random.Range(0f, 5f);       
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                 obj = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), new Vector3(-15.88f, -2.89f, 0), Quaternion.identity, 0);
                obj.name = "Player" + PhotonNetwork.player.ID;

                break;
            case 2:
                 obj2 = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player2"), new Vector3(-15.88f, -2.89f, 0), Quaternion.identity, 0);
                obj2.name = "Player" + PhotonNetwork.player.ID;
                break;
        }
       
       // LobbyNetwork.instance.number++;

    }    
    public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        Debug.Log(newMasterClient.NickName);
    }
    public void Boost()
    {

    }

}
