using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLayoutGroup : MonoBehaviour {

    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject PlayerListingPrefab
    {
        get { return _playerListingPrefab; }
    }

    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }

    public Button BtnState;
    public Button BtnStart;   
    //Called by photon whenever the master client is swithced.
    private void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
      //  PhotonNetwork.SetMasterClient(newMasterClient);
        Debug.Log(newMasterClient.NickName);    
        if (PhotonNetwork.isMasterClient)
        {       
            if (CurrentRoomCanvas.NbPlayerReady == PhotonNetwork.room.MaxPlayers)
            {
                BtnStart.gameObject.SetActive(true);
            }
            BtnState.gameObject.SetActive(true);
        }

    }


    //Called by photon whenever you join a room.
    private void OnJoinedRoom()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
            /////////////////////////////////
        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling();

        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }

    //Called by photon when a player joins the room.
    private void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }

    //Called by photon when a player leaves the room.
    private void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }


    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
            return;

        if (!PhotonNetwork.isMasterClient)
        {
            BtnState.gameObject.SetActive(false);
            BtnStart.gameObject.SetActive(false);
        }

        PlayerLeftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerListingPrefab);
        playerListingObj.transform.SetParent(transform, false);

        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);

        PlayerListings.Add(playerListing);
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }

    public void OnClickRoomState()
    {
        if (!PhotonNetwork.isMasterClient)      
            return;
        PhotonNetwork.room.IsOpen = !PhotonNetwork.room.IsOpen;
        PhotonNetwork.room.IsVisible = PhotonNetwork.room.IsOpen;
    }

    public void OnClickLeaveRoom()
    {    
        GameObject lobbyCanvasObj = MainCanvasManager.Instance.CurrentRoomCanvas.gameObject;
        if (lobbyCanvasObj == null)
            return;
        CurrentRoomCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<CurrentRoomCanvas>();
        lobbyCanvas.OnReadyState(true);
     
        PhotonNetwork.LeaveRoom(true);
    }
}
