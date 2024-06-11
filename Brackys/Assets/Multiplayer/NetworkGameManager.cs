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
    [SerializeField] public static int playerCount;

    public void Host()
    {
        StartHost();
    }

    public void Client()
    {
        StartClient();
    }

    public void PauseGame()
    {
        pauseLevelUI.SetActive(true);
        gameIsPaused = true;
    }

    private void OnPlayerConnected()
    {
        playerCount++;
        Debug.Log("Player connected. Total players: " + playerCount);
    }
}
