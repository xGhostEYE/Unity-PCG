using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 25f;
    [SerializeField] GameObject rewardEgg;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        health-=damageAmount;
        if(health <= 0)
        {
            if (Random.Range(0.0f, 1.0f) < 0.3)
            {
                Instantiate(rewardEgg,this.gameObject.transform.position,Quaternion.identity);
            }
           Destroy(gameObject);
        }
    }
}
