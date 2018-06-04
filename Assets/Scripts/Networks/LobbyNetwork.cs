using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LobbyNetwork : MonoBehaviour
    {
        public static LobbyNetwork instance;
        public Text RoomName;
        public Text JoinedRoomName;
        public int number = 0;
        public List<Vector3> listInt = new List<Vector3> { new Vector3(0, 16, -27), new Vector3(-2, 16, -27) };


    void Start()
        {
            if (!PhotonNetwork.connected)
            {
                PhotonNetwork.ConnectUsingSettings("0.0.0");
                print("connecting to the server");
            }
        }


    public  void OnConnectedToMaster()
        {  
        print("connection master");        
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        Debug.Log(PhotonNetwork.playerName);
        PhotonNetwork.automaticallySyncScene = false;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public void OnJoinedLobby()
        {
        Debug.Log("Joined Lobby");
        if (!PhotonNetwork.inRoom)
        {  
            //////////////////////////////////////////
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
        }
        }

        void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        public void OnClick_CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };

            RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0)
        {
            Debug.Log("Room dos not exist");

            if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
            {

                print("create room successfully sent.");
            }
            else
            {
                print("create room failed to send");
            }
        }
        else
        {
            foreach (RoomInfo room in rooms)
            {
                if (RoomName.text.Equals(room.Name))
                {
                    Debug.Log("This room exists !");
                    break;
                }
                else
                {
                    if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
                    {

                        print("create room successfully sent.");
                    }
                    else
                    {
                        print("create room failed to send");
                    }
                }
            }
        }
        }

        public void OnPhotonCreateRoomFailed(object[] codeAndMessage)
        {
            print("create room failed: " + codeAndMessage[1]);
        }

        public void OnCreatedRoom()
        {
            Debug.Log("Created Room ");
        }



        public void JoinGame()
        {
            RoomInfo[] rooms = PhotonNetwork.GetRoomList();
       
            if (rooms.Length == 0)
            {
                Debug.Log("Room does not exist");
            }else
            {
                foreach (RoomInfo room in rooms)
                {
                    if (JoinedRoomName.text.Equals(room.Name))
                    {
                        if (room.PlayerCount < room.MaxPlayers)
                        {
                            Debug.Log(room.PlayerCount);
                            PhotonNetwork.JoinRoom(room.Name);
                        }
                        else
                        {
                            Debug.Log("Room in max players: "+ room.PlayerCount);
                        }
                
                    }
                    else
                    {
                        Debug.Log("Room does not exist");
                    }
                }
            }
                     
        }


        public void OnReceivedRoomListUpdate()
        {
            RoomInfo[] rooms = PhotonNetwork.GetRoomList();

            foreach (RoomInfo room in rooms)
            {
              Debug.Log("Room name1: " + room.Name);
            }

    
        }


    public void LeftRoom()
    {
        if (PhotonNetwork.inRoom)
        {
            PhotonNetwork.LeaveRoom(true);
            SceneManager.LoadScene("MultiplayerLobby");
        }
        else
        {
            Debug.Log("not in room");
        }
    }


   


}