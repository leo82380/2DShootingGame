using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = Random.Range(0, enemy.Length);
        GameObject a = Instantiate(enemy[i]);
    }
}
