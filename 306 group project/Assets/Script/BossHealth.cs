using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float Hitpoints;
    [SerializeField] GameObject reward;

    public float MaxHitPoints = 100;
    //public healthBarBehaviour HealthBar;

    private void Start()
    {
        Hitpoints = MaxHitPoints;
        //HealthBar.SetHealth(Hitpoints, MaxHitPoints);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        //HealthBar.SetHealth(Hitpoints, MaxHitPoints);
        if(Hitpoints <= 0)
        {
            GetComponent<Animator>().Play("Die");
            Instantiate(reward, new Vector3(205, 203), Quaternion.identity);
            GameObject.FindGameObjectWithTag("portal_end_2").GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Gate"));
            GameObject.FindGameObjectWithTag("portal_end_2").GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
