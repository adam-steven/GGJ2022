using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;

public class TwitchChatController : MonoBehaviour
{
    public UnityEvent<string, string> OnChatMessage;

    TcpClient Twitch;
    StreamReader Reader;
    StreamWriter Writer;

    const string url = "irc.chat.twitch.tv";
    const int port = 6667;

    string user = "GGJ2022_TwitchDriving";
    static string oauth = "oauth:89kt3g7rtdb9bnp6leyot4fnmi4ekd";
    string channel = "Kall_Me_Klik";

    float pingCounter = 0;

    private void Awake()
    {
        ConnectToTwitch();
    }

    private void ConnectToTwitch()
    {
        Twitch = new TcpClient(url, port);
        Reader = new StreamReader(Twitch.GetStream());
        Writer = new StreamWriter(Twitch.GetStream());

        Writer.WriteLine("PASS " + oauth);
        Writer.WriteLine("NICK " + user.ToLower());
        Writer.WriteLine("JOIN #" + channel.ToLower());
        Writer.Flush();
    }

    void Update()
    {
        //If stagnant communication ping to keep alive
        pingCounter += Time.deltaTime;
        if(pingCounter > 60)
        {
            Writer.WriteLine("PING " + url);
            Writer.Flush();
            pingCounter = 0;
        }

        if (!Twitch.Connected)
        {
            ConnectToTwitch();
        }

        if(Twitch.Available > 0)
        {
            string massage = Reader.ReadLine();

            if(massage.Contains("PRIVMSG"))
            {
                //:kall_me_klik!kall_me_klik@kall_me_klik.tmi.twitch.tv PRIVMSG #kall_me_klik :hello felix

                int splitPoint = massage.IndexOf("!");
                string chatter = massage.Substring(1, splitPoint - 1);

                splitPoint = massage.IndexOf(":" , 1);
                string msg = massage.Substring(splitPoint - 1);

                OnChatMessage?.Invoke(chatter, msg);
            }
            
        }
    }
}
