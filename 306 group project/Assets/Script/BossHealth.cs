using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float Hitpoints;

    public float MaxHitPoints = 100;
   // public healthBarBehaviour HealthBar;

    private void Start()
    {
        Hitpoints = MaxHitPoints;
       // HealthBar.SetHealth(Hitpoints, MaxHitPoints);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        //HealthBar.SetHealth(Hitpoints, MaxHitPoints);
        if(Hitpoints <= 0)
        {
            GetComponent<Animator>().Play("Die");
            Destroy(gameObject);
            //Instantiate((GameObject)Resources.Load("Dragon_Egg_01"), new Vector3(205, 203), Quaternion.identity);
            //GameObject.FindGameObjectWithTag("portal_end_2").SetActive(true);
        }
    }

}
