using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TMP_Text scoreText;
    int score;
    public int Score
    {
        get => score;
        set => Mathf.Max(0, value);
    }

    private void Awake()
    {
        scoreText = FindObjectOfType<TMP_Text>();
        scoreText.text = "score : 0";
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
}
