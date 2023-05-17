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
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnEnable()
    {
        die = GetComponent<Animator>();
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
        transform.position += dir.normalized * Time.deltaTime * playerMoveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x + right, maxpos.x - left),
            Mathf.Clamp(transform.position.y, minpos.y + bottom, maxpos.y - top), 0);
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
        
        while (count < 4)
        {

            
            playerSprite.color = new Color(0, 0, 0, 0.3f);
            yield return new WaitForSeconds(0.25f);

            playerSprite.color = new Color(0, 0, 0, 0.3f);
            yield return new WaitForSeconds(0.25f);
            count++;
        }

        circleCollider.enabled = true;
    }
}
