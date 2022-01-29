using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] float speedIncrease = 0f;
    [SerializeField] float pointIncrease = 0f;
    [SerializeField] bool isGameOverObstacle = false; // Whether this obstacle will result in a game over condition.

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
