using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour {

    public PhotonPlayer PhotonPlayer { get; private set; }
    [SerializeField]
    private Text _playerName;
    private Text PlayerName
    {
        get { return _playerName; }
    }

    [SerializeField]
    private Text _playerPing;
    private Text m_playerPing
    {
        get { return _playerPing; }
    }


    public  Button ReadyButton;
    public  Text ReadyText;

 
    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        PhotonPlayer = photonPlayer;
        PlayerName.text = photonPlayer.NickName;
        ReadyButton.name = photonPlayer.ID.ToString();
        StartCoroutine(C_ShowPing());
    }


    private void Start()
    {
        GameObject lobbyCanvasObj = MainCanvasManager.Instance.CurrentRoomCanvas.gameObject;
        if (lobbyCanvasObj == null)
            return;
        CurrentRoomCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<CurrentRoomCanvas>();
        //  Button button = GetComponent<Button>();        
        ReadyButton.onClick.AddListener(() => lobbyCanvas.OnReadyButton(PhotonPlayer));        
    }

   
    private IEnumerator C_ShowPing()
    {
        while (PhotonNetwork.connected)
        {
            int ping = (int)PhotonPlayer.CustomProperties["Ping"];
            m_playerPing.text = ping.ToString()+ " ms";
            yield return new WaitForSeconds(1f);
        }

        yield break;
    }
}
