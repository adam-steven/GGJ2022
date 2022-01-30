using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    CarState carState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteVote(Vote v)
    {
        switch (v)
        {
            case Vote.Lane1:
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;
            case Vote.Lane2:
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;
            case Vote.Lane3:
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;
            case Vote.Lane4:
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;
            default:
                Debug.LogWarning("This vote result is not processed by the car script.");
                break;
        }
    }
}
