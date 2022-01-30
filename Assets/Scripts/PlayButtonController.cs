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
        string user = PlayerPrefs.GetString("twitchUser").Trim();
        string pass = PlayerPrefs.GetString("twitchToken").Trim();
        bool noUserPrevEntered = user.Any(x => !char.IsLetter(x));

        if (!noUserPrevEntered)
        {
            username.text = PlayerPrefs.GetString("twitchUser");
            passowrd.text = PlayerPrefs.GetString("twitchToken");
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
