using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 5;
    Vector3 minpos;
    Vector3 maxpos;
    [SerializeField] float top;
    [SerializeField] float bottom;
    [SerializeField] float right;
    [SerializeField] float left;
    // Start is called before the first frame update
    void Start()
    {
        minpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0);
        transform.position += dir.normalized * Time.deltaTime * playerMoveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x + right, maxpos.x - left),
            Mathf.Clamp(transform.position.y, minpos.y + bottom, maxpos.y - top), 0);
    }
}
