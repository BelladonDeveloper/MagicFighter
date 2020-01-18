using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float health = 100;

    void Update()
    {
        //bar.fillAmount = health / 100;
        bar.rectTransform.localPosition = new Vector2(health - 100, 0);
    }
}
