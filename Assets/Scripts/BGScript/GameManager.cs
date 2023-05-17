using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static TMP_Text scoreText;
    int score;
    public int Score
    {
        get => score;
        set => Mathf.Max(0, value);
    }

    private void Awake()
    {
        scoreText = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(0).GetComponent<TMP_Text>();
        scoreText.text = "score : " + score;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "score : " + score;
        Debug.Log(Score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
