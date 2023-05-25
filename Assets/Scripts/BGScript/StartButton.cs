using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject startPanal;
    [SerializeField] GameObject playPanal;
    [SerializeField] Player_Controller player;
    DOTweenTest tween;
    private void Start()
    {
        startPanal = GameObject.Find("StartPanal");
        tween = GameObject.Find("StartPanal").GetComponent<DOTweenTest>();
        player = GameObject.Find("PlayerSpawnPos").transform.GetChild(0).GetComponent<Player_Controller>();
    }
    public void StartGame()
    {
        StartCoroutine(tween.FadeOut());
        StartCoroutine(StartPanalOff());
        player.isgame = true;
        playPanal.SetActive(true);
        player.gameObject.SetActive(true);
    }
    IEnumerator StartPanalOff()
    {
        yield return new WaitForSeconds(1);
        startPanal.SetActive(false);
    }
}
