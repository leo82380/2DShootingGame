using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    [SerializeField] float bg_Speed = 5;
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * bg_Speed;
        if(transform.position.y <= -12)
        {
            transform.position = new Vector3(0, 12, 0);
        }
    }
}
