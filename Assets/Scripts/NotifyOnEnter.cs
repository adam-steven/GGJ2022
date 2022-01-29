using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyOnEnter : MonoBehaviour
{
    public string ObjectTag = "Car";
    public MonoBehaviour ScriptToNotify;
    public string FunctionName;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(ObjectTag))
        {
            ScriptToNotify.Invoke(FunctionName, 0f);
        }
    }
}
