using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandeler : MonoBehaviour
{
    private List<string> alreadyVotedUsers = new List<string>();

    private string[] commands = { "1", "2", "3", "4", "faster", "slower" };
    private int[] voteTally = { 0, 0, 0, 0, 0, 0 };
    public void OnChatMessage(string user, string msg)
    {
        if (alreadyVotedUsers.Contains(user)) return;
        bool valid = AddVote(msg);

        if (valid)
        {
            alreadyVotedUsers.Add(user);
            print(msg);
        }
    }

    //return true if vote is valid
    private bool AddVote(string value)
    {
        for (int i = 0; i < commands.Length; i++)
        {
            if (value.ToLower().Contains(commands[i]))
            {
                voteTally[i] += 1;
                return true;
            }
        }
        
        if(value.ToLower().Contains("random"))
        {
            string randomVote = Random.Range(1, 5).ToString();
            return AddVote(randomVote);
        }

        return false;
    }

    public string GetDecision()
    {
        int maxValue = voteTally.Max();
        int maxIndex = voteTally.ToList().IndexOf(maxValue);

        //reset structures
        alreadyVotedUsers.Clear();
        for (int i = 0; i < voteTally.Length; i++)
        {
            voteTally[i] = 0;
        }

        return commands[maxIndex];
    }
}
