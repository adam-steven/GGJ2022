using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrentTime : MonoBehaviour
{
    TextMeshProUGUI gui;
    [SerializeField] string timeLocale = "en-GB";

    void Start()
    {
        gui = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gui.text = "Current UTC Time: " + DateTime.UtcNow.Hour + ":" + DateTime.UtcNow.Minute + ":" + DateTime.UtcNow.Second;
    }
}
