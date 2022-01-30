using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private TimeManager timeManager;

    private int score;

    [SerializeField] public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public void DoGameOver()
    {
        timeManager.CancelInvoke();
        timeManager.TimerState = TimeManagerState.Stopped;
        GameOverText.SetActive(true);
        Invoke(nameof(LoadMainMenu), 5f);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }



    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
    }
}
