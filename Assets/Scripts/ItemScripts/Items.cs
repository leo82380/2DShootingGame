using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    
    [SerializeField] float speed;
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
