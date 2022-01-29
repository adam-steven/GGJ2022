using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallyTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            ChoiceHandeler ch = this.GetComponent<ChoiceHandeler>();
            Debug.Log(ch.GetDecision());
        }
    }
}
