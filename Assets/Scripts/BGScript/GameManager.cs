using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static TMP_Text scoreText;
    int score;
    public Image[] hpImage;
    public Player_Controller player;
    int hp = 3;
    public GameObject GameOverPanal;
    public GameObject GamePanal;
    public bool isGameover;
    public TMP_Text bestScoreText;
    string keyName = "BestScore";
    int bestScore = 0;
    public TMP_Text gameoverBestScore;
    private void OnEnable()
    {
        scoreText = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(0).GetComponent<TMP_Text>();
    }
    public int Score
    {
        get => score;
        set => Mathf.Max(0, value);
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        scoreText = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(0).GetComponent<TMP_Text>();
        scoreText.text = "score : " + score;
        hp = 3;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        bestScore = PlayerPrefs.GetInt(keyName, 0);
        bestScoreText.text = "Best: " + bestScore.ToString();
    }
    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "score : " + score;
        Debug.Log(Score);
        if(score > bestScore)
        {
            PlayerPrefs.SetInt(keyName, score);
            bestScoreText.text = "Best: " + bestScore.ToString();
        }
    }
    public void ResetScore()
    {
        score = 0;
    }
    public void MinusHP()
    {
        hp--;
        Debug.Log("hp : " + hp);
        UpdateLifeIcons();
        if (hp <= 0)
        {
            GameOver();
            isGameover = true;
        }
        else
        {
            StartCoroutine(PlayerRespawn());
        }
    }
    void GameOver()
    {
        
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] dirs = GameObject.FindGameObjectsWithTag("dir");
        GameObject[] powers = GameObject.FindGameObjectsWithTag("Power");
        var obj = enemys.Concat(dirs);
        var obj2 = obj.Concat(powers);
        for (int i = 0; i < obj2.ToArray().Length; i++)
        {
            Destroy(obj2.ToArray()[i]);
        }
        
        GameOverPanal.SetActive(true);
        GamePanal.SetActive(false);
        PlayerPrefs.GetInt(keyName, 0);
        gameoverBestScore.text = "Best: " + bestScore.ToString();
    }
    void UpdateLifeIcons()
    {
        if (hp < 0) return;
        hpImage[hp].enabled = false;
    }
    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        player.gameObject.SetActive(true);
    }
}
