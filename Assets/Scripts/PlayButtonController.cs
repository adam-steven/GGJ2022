using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField passowrd;

    void Start()
    {
        string user = PlayerPrefs.GetString("twitchUser");
        string pass = PlayerPrefs.GetString("twitchToken");
        bool noUserPrevEntered = user.Length < 3;

        if (!noUserPrevEntered)
        {
            username.text = user;
            passowrd.text = pass;
        }
    }

    public void OnClick()
    {
        if (string.IsNullOrEmpty(username.text) || string.IsNullOrEmpty(passowrd.text)) return;

        PlayerPrefs.SetString("twitchUser", username.text);
        PlayerPrefs.SetString("twitchToken", passowrd.text);

        SceneManager.LoadScene("Game");
    }
}
