using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{

    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    BossHealth boss;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        boss = FindObjectOfType<BossHealth>();
        
    }

    private void Update()
    {
        CurrentHealth = boss.Hitpoints;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

}
