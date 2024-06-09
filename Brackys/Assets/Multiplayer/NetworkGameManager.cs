using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Networking;
using UnityEngine.SceneManagement;

public class NetworkGameManager : NetworkManager
{
    public void OnNetworkSpawn()
    {
        if (!IsHost) { Destroy(this); }
    }

    public bool gameIsPaused = false;
    public GameObject pauseLevelUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PauseGame()
    {
        pauseLevelUI.SetActive(true);
        gameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        var numOfConnectedPlayers = Network.connections.Length;
    }
}
