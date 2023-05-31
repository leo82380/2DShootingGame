using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]);
        }
        for (int i = 0; i < dirs.Length; i++)
        {
            Destroy(dirs[i]);
        }
        GameOverPanal.SetActive(true);
        GamePanal.SetActive(false);
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
