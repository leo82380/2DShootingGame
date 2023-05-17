using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShot : MonoBehaviour
{
    [SerializeField] float enemyBulletSpeed = 3;
    void Update()
    {
        transform.position += Vector3.down * enemyBulletSpeed * Time.deltaTime;
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
