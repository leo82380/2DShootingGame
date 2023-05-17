using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    float delTime;
    // Start is called before the first frame update
    void Start()
    {
        delTime += Time.deltaTime;
        if(delTime >= 0.5f)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            delTime = 0;
        }
    }
    
}
