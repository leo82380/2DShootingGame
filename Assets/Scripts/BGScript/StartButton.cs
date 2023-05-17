using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject startPanal;
    [SerializeField] GameObject playPanal;
    [SerializeField] Player_Controller player;
    private void Start()
    {
        startPanal = GameObject.Find("StartPanal");
        player = FindObjectOfType<Player_Controller>();
    }
    public void StartGame()
    {
        player.isgame = true;
        startPanal.SetActive(false);
        playPanal.SetActive(true);
    }
}
