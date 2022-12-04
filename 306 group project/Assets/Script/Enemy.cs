using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        health-=damageAmount;
        if(health < 0)
        {
           Destroy(gameObject);
        }
    }
}
