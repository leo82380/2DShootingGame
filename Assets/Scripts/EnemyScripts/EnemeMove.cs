using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMove : MonoBehaviour
{
    [SerializeField] float enemySpeed = 7;
    Vector3 dir;
    Player_Controller player;
    private void Awake()
    {
        player = FindObjectOfType<Player_Controller>();
    }
    private void Start()
    {
        int rd = Random.Range(0, 100);
        if(rd < 30)
        {
            dir = player.transform.position - transform.position;
        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        transform.position += dir.normalized * Time.deltaTime * enemySpeed;
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
