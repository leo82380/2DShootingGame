using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 7;
    public IObjectPool<GameObject> pool { get; set; }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * bulletSpeed;
        if(transform.position.y >= 10)
        {
            pool.Release(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            pool.Release(this.gameObject);
        }
    }
}
