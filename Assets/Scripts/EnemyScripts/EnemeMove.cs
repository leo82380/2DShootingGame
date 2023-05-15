using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMove : MonoBehaviour
{
    [SerializeField] float enemySpeed = 7;
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * enemySpeed;
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
