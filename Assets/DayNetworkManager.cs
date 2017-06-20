using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DayNetworkManager : NetworkManager 
{
    public void OnClientConnect(NetworkConnection conn){
        ClientScene.Ready(conn);
        ClientScene.AddPlayer(0);
    }
}
