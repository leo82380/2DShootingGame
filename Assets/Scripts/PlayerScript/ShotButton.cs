using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotButton : MonoBehaviour
{
    float clickTime;
    public float minClickTime = 1;
    public bool isClick;
    public Player_Controller player;
    public void ButtonDown()
    {
        isClick = true;
    }

    public void ButtonUP()
    {
        isClick = false;
        print(clickTime);

        if(clickTime >= minClickTime)
        {
            StartCoroutine(player.Shot());
        }
    }
    private void Update()
    {
        if (isClick)
        {
            clickTime += Time.deltaTime;
        }
        else
        {
            clickTime = 0;
        }
    }
}
