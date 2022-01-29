using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VoteTally
{
    public Vote voteGroup;
    public uint votes;

    public VoteTally(Vote voteGroup, uint votes=0)
    {
        this.voteGroup = voteGroup;
        this.votes = votes;
    }

    public void ResetVotes()
    {
        votes = 0;
    }
}

public class DemocracyManager : MonoBehaviour
{
    public List<VoteTally> voteTallies;

    // Start is called before the first frame update
    void Start()
    {
        voteTallies = new List<VoteTally>();
        voteTallies.Add(new VoteTally(Vote.Lane1));
        voteTallies.Add(new VoteTally(Vote.Lane2));
        voteTallies.Add(new VoteTally(Vote.Lane3));
        voteTallies.Add(new VoteTally(Vote.Lane4));
        voteTallies.Add(new VoteTally(Vote.SpeedUp));
        voteTallies.Add(new VoteTally(Vote.SlowDown));
        voteTallies.Add(new VoteTally(Vote.Random));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVotingOpen()
    {

    }

    public void CloseVoting()
    {

    }

    public void TallyVotes(out Vote winner)
    {
        winner = Vote.Unset;
    }
}
