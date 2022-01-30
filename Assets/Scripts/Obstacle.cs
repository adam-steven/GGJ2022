using System;
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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Car"))
        {
            col.gameObject.GetComponent<Car>().HasBeenHit(pointIncrease, speedIncrease, isGameOverObstacle);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
