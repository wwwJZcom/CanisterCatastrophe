using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    void Update()
    {
        if (gameObject.GetComponent<Player>().isTouchingEnemy == false)
        {
            fill.color = gradient.Evaluate(1f);
        }

        if (gameObject.GetComponent<Player>().isTouchingEnemy == true)
        {
            fill.color = gradient.Evaluate(0.1f);
        }
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


    public void LifetimeHealth(int health)
    {
        slider.value = health;
    }
}