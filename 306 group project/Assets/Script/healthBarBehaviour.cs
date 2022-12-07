using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarBehaviour : MonoBehaviour
{

    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 Offset;

    public void SetHealth( float health, float maxHealth)
    {
        //Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }

     void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }


}
