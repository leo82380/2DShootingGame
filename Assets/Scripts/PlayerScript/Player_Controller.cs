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

    [SerializeField] GameObject playerBullet;
    [SerializeField] float delTime;
    [SerializeField] GameObject gamePanal;
    public bool isgame = false;
    Animator die;
    CircleCollider2D circleCollider;
    SpriteRenderer playerSprite;
    [SerializeField] Transform playerSpawnPos;
    bool isdir;
    int dirSwich = 1;
    private void OnEnable()
    {
        die = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        minpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = playerSpawnPos.position;
        StartCoroutine(Revive());
    }
    void Update()
    {
        if (isgame == true)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Shot());
            }
        }
    }
    IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(playerBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(delTime);
            }
            yield return null;
        }
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0);
        transform.position += dir.normalized * Time.deltaTime * playerMoveSpeed * dirSwich;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x + right, maxpos.x - left),
            Mathf.Clamp(transform.position.y, minpos.y + bottom, maxpos.y - top), 0);
        if (isdir == true)
        {
            dirSwich = -1;
        }
        else
        {
            dirSwich = 1;
        }
    }
    public void DieEvent()
    {
        GameManager.instance.MinusHP();
        gameObject.SetActive(false);
    }
    public void DiePlayer()
    {
        die.SetTrigger("onDie");
        circleCollider.enabled = false;
    }
    IEnumerator Revive()
    {
        int count = 0;
        Color color = playerSprite.color;
        while (count < 4)
        {
            color.a = 0.3f;
            playerSprite.color = color;
            yield return new WaitForSeconds(0.25f);
            color.a = 1f;
            playerSprite.color = color;
            yield return new WaitForSeconds(0.25f);
            count++;
        }

        circleCollider.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dir"))
        {
            isdir = true;
            playerSprite.flipY = true;
            Destroy(collision.gameObject);
            StartCoroutine(dirFalse());
        }
    }
    IEnumerator dirFalse()
    {
        yield return new WaitForSeconds(3);
        playerSprite.flipY = false;
        isdir = false;
    }
}
