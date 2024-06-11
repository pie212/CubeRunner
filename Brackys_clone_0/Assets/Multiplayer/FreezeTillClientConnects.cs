using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Networking;

public class FreezeTillClientConnects : NetworkBehaviour
{

    private void OnNetworkInstantiate()
    {
        if (!IsOwner) { Destroy(this); }
    }

    // Flag to check if a client is connected
    private bool clientConnected = false;

    public GameObject WaitUI;

    void Start()
    {
       GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnPlayerConnected()
    {
        clientConnected = true;
        Destroy(WaitUI);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
