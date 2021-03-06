using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UIElements;
using TMPro;

public enum TimeManagerState
{
    Stopped,
    VotingOpen,
    CountingVotes,
    MovingCar
}

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI currentStateText;

    [SerializeField] string stoppedStateText = "Get Ready To Vote...";
    [SerializeField] string votingOpenStateText = "Voting Open!";
    [SerializeField] string countingVotesStateText = "Counting Votes...";
    [SerializeField] string movingCarStateText = "Democracy in Progress...";

    [SerializeField] public float CountInTime = 15f;
    [SerializeField] private float voteTime = 25f;
    public float VoteTime
    {
        get
        {
            return voteTime;
        }
        set
        {
            voteTime = value;
            voteTime = Mathf.Clamp(voteTime, 10f, 9999f);
        }
    }
    [SerializeField] public float VotingClosedTime = 15f; // 15s

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

        currentStateText.text = stoppedStateText;

    }

    // Update is called once per frame
    void Update()
    {
        TimeRemainingOnCurrentSection -= Time.deltaTime;
        TimeRemainingOnCurrentSection = Mathf.Clamp(TimeRemainingOnCurrentSection, 0f, float.PositiveInfinity);

        timerText.text = TimeRemainingOnCurrentSection.ToString("0");
    }

    void ChangeStateIntoVotingOpen()
    {
        TimerState = TimeManagerState.VotingOpen;
        democracyManager.OnVotingOpen();
        currentStateText.text = votingOpenStateText;
        TimeRemainingOnCurrentSection = VoteTime;
        Invoke("ChangeStateIntoCountingVotes", VoteTime);
        obstacleManager.SetAdvanceSpeed((((obstacleManager.segmentsPerLane - 3f) * obstacleManager.segmentPrefabSize)) / (VoteTime + VotingClosedTime));
    }

    void ChangeStateIntoCountingVotes()
    {
        currentStateText.text = countingVotesStateText;
        TimeRemainingOnCurrentSection = VotingClosedTime;
        Invoke("ChangeStateIntoMovingCar", VotingClosedTime);
    }

    void ChangeStateIntoMovingCar()
    {
        democracyManager.CloseVoting();
        democracyManager.TallyVotes(out var winner);
        currentStateText.text = movingCarStateText;
        if (winner == Vote.Lane1 || winner == Vote.Lane2 || winner == Vote.Lane3 || winner == Vote.Lane4)
        {
            car.ExecuteVote(winner);
        }
        else if (winner == Vote.SpeedUp)
        {
            VoteTime -= 1f;
        }
        else if (winner == Vote.SlowDown)
        {
            VoteTime += 1f;
        }
    }

    public void TransitionIntoNewObstacle()
    {
        ChangeStateIntoVotingOpen();
    }
}
