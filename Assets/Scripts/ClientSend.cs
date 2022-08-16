using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet packet)
    {
        packet.WriteLength();
        Client.instance.tcp.SendData(packet);
    }

    private static void SendUDPData(Packet packet)
    {
        packet.WriteLength();
        Client.instance.udp.SendData(packet);
    }


    #region Packets

    public static void WelcomeReceived()
    {
        using (Packet packet = new Packet((int)ClientPackets.WelcomeReceived))
        {
            packet.Write(Client.instance.myId);
            packet.Write(UIManager.instance.usernameField.text);
            
            SendTCPData(packet);
        }
    }

    public static void SendUDPTestReceived()
    {
        using (Packet packet = new Packet((int)ClientPackets.UdpTestReceived))
        {
            packet.Write("Received an UDP packet");
            SendUDPData(packet);
        }
    }
    
    #endregion
}
