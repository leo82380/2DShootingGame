using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] float delTime = 0.2f;
    [SerializeField] Player_Controller player;
    bool isSpawn;
    float curtime = 0;
    public bool ishard;
    [SerializeField]TMP_Text hardmord;
    private void Start()
    {
        player = GameObject.Find("PlayerSpawnPos").transform.GetChild(0).GetComponent<Player_Controller>();
        isSpawn = true;
        ishard = false;
    }
    private void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            if (player.isgame == true)
            {
                curtime += Time.deltaTime;
                hardmord.text = "Time: " + (int)curtime;
                if (curtime == 10)
                {
                    delTime = 0.3f;
                    ishard = true;
                    hardmord.text = "no Hardmord on";
                }
                if (isSpawn == true)
                {
                    StartCoroutine("EnemySpawn");
                    isSpawn = false;
                }
            }
        }
        else
        {
            StopCoroutine("EnemySpawn");
        }
    }
    IEnumerator EnemySpawn()
    {
        while (true)
        {
            int i = Random.Range(0, enemy.Length);
            GameObject enemys = Instantiate(enemy[i]);
            int rdIndex = Random.Range(0, transform.childCount);
            enemys.transform.position = transform.GetChild(rdIndex).position;
            yield return new WaitForSeconds(delTime);
        }
    }

}
