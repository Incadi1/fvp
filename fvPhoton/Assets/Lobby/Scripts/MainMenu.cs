using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviourPunCallbacks
{
    private bool isConnecting = false;

    public GameObject Panel_NameImput;
    public GameObject Panel_Waiting;

    //private const string GameVersion = "0.1";
    //private const int MaxPlayersPerRoom = 2;

    void Start()
    {
        Panel_NameImput.SetActive(true);
        Panel_Waiting.SetActive(false);

    }
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ConnectServerPhoton()
     {
        isConnecting = true;

        if (!(PhotonNetwork.IsConnected))
        {
            PhotonNetwork.ConnectUsingSettings();
            Panel_NameImput.SetActive(false);
            Panel_Waiting.SetActive(true);
        }
    }

    public override void OnConnected()
    {
        base.OnConnected();
    }


    public override void OnConnectedToMaster()
    {
        

        base.OnConnectedToMaster();
        Debug.Log("Bienvenido a photon  " + PhotonNetwork.NickName);

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Desconectado debido a: {cause}");
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOps = new RoomOptions();

        roomOps.IsVisible = true;
        roomOps.IsOpen = true;

        string roomName = "Room" + Random.Range(0, 1000);
        PhotonNetwork.CreateRoom(roomName, roomOps);

    }




    public override void OnJoinedRoom()
    {
        Debug.Log("Esta listo para entrar a la habitación");

        PhotonNetwork.LoadLevel(1);
        
    }

    
}
