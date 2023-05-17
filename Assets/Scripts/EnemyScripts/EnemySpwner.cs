using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] float delTime = 0.2f;
    [SerializeField] Player_Controller player;
    bool isSpawn;
    private void Start()
    {
        player = FindObjectOfType<Player_Controller>();
        isSpawn = true;
    }
    private void Update()
    {
        if (player.isgame == true)
        {
            if (isSpawn == true)
            {
                StartCoroutine(EnemySpawn());
                isSpawn = false;
            }
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
