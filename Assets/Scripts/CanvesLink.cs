using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvesLink : MonoBehaviour
{
    public void OpenLink()
    {
        Application.OpenURL("https://twitchapps.com/tmi/");
    }

    public void OnHover()
    {
        TextMeshProUGUI text = this.GetComponent<TextMeshProUGUI>();
        text.color = Color.blue;
    }

    public void OnExit()
    {
        TextMeshProUGUI text = this.GetComponent<TextMeshProUGUI>();
        text.color = Color.black;
    }
}
