using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOTweenTest : MonoBehaviour
{
    public Image panal;
    public IEnumerator FadeOut()
    {
        panal.DOFade(0, 1);
        yield return null;
    }
}
