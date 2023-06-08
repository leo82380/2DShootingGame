using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject[] startPanal;
    [SerializeField] GameObject playPanal;
    [SerializeField] Player_Controller player;
    [SerializeField] GameObject start;
    [SerializeField] GameObject copy;
    DOTweenTest tween;
    private void Start()
    {
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
        for (int i = 0; i < startPanal.Length; i++)
        {
            startPanal[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1);
        start.gameObject.SetActive(false);
    }
    public void CopyRight()
    {
        copy.SetActive(true);
    }
    public void CopyActive()
    {
        copy.SetActive(false);
    }
}
