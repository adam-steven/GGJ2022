using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    CarState carState;

    private TimeManager timeManager;
    private ObstacleManager obstacleManager;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        obstacleManager = GameObject.FindObjectOfType<ObstacleManager>();
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
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                break;
            case Vote.Lane2:
                transform.position = new Vector3(1f, transform.position.y, transform.position.z);
                break;
            case Vote.Lane3:
                transform.position = new Vector3(2f, transform.position.y, transform.position.z);
                break;
            case Vote.Lane4:
                transform.position = new Vector3(3f, transform.position.y, transform.position.z);
                break;
            default:
                Debug.LogWarning("This vote result is not processed by the car script.");
                break;
        }
    }

    public void HasBeenHit(float pts, float speedIncrease, bool isGameOver)
    { 
        if (isGameOver)
            scoreManager.DoGameOver();

        timeManager.VoteTime -= speedIncrease;
        scoreManager.Score += (int)pts;
    }
}
