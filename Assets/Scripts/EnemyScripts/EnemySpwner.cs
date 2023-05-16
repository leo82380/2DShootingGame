using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] float delTime = 0.2f;
    private void Start()
    {
        StartCoroutine(EnemySpawn());
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
