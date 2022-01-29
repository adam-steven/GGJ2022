using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UIElements;

public enum TimeManagerState
{
    Stopped,
    VotingOpen,
    CountingVotes,
    MovingCar
}

public class TimeManager : MonoBehaviour
{
    [SerializeField] float CountInTime = 15f;
    [SerializeField] float VoteTime = 25f;
    [SerializeField] float VotingClosedTime = 15f; // 15s

    public TimeManagerState TimerState = TimeManagerState.Stopped;

    public float TimeRemainingOnCurrentSection;

    DemocracyManager democracyManager;
    ObstacleManager obstacleManager;
    Car car;


    // Start is called before the first frame update
    void Start()
    {
        TimeRemainingOnCurrentSection = CountInTime;
        Invoke("ChangeStateIntoVotingOpen", CountInTime);
        democracyManager = GameObject.FindObjectOfType<DemocracyManager>();
        obstacleManager = GameObject.FindObjectOfType<ObstacleManager>();
        car = GameObject.FindObjectOfType<Car>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChangeStateIntoVotingOpen()
    {
        TimerState = TimeManagerState.VotingOpen;
        democracyManager.OnVotingOpen();
    }

    void ChangeStateIntoVotingClosed()
    {

    }

    void ChangeStateIntoMovingCar()
    {
        democracyManager.OnVotingClose();
        democracyManager.OnTallyVotes(out var winner);
    }
}
