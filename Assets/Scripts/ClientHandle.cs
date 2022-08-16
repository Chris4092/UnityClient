using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet packet)
    {
        string msg = packet.ReadString();
        int myId = packet.ReadInt();
        Debug.Log($"Message from server: {msg}");
        Client.instance.myId = myId;
        
        ClientSend.WelcomeReceived();
        
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void UDPTest(Packet packet)
    {
        string msg = packet.ReadString();
        // int myId = packet.ReadInt();
        Debug.Log($"Received packet via UDP. Message found: {msg}");
        ClientSend.SendUDPTestReceived();
    }
}
