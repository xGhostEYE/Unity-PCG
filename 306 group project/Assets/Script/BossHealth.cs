using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float Hitpoints;

    public float MaxHitPoints = 5;
    public healthBarBehaviour HealthBar;

    private void Start()
    {
        Hitpoints = MaxHitPoints;
        HealthBar.SetHealth(Hitpoints, MaxHitPoints);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitPoints);
        if(Hitpoints <= 0)
        {
            GetComponent<Animator>().Play("Die");
            Destroy(gameObject);
        }
    }
}
