using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void ReStartBtn()
    {
        GameManager.instance.ResetScore();
        SceneManager.LoadScene(0);
    }
}
