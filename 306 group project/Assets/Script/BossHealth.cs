using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float Hitpoints;
    [SerializeField] GameObject reward;

    public float MaxHitPoints = 100;

    private void Start()
    {
        Hitpoints = PlayerInfo.Instance.hp* Random.Range(0.7f,1.4f) + PlayerInfo.Instance.LevelCounter*Random.Range(1.0f, 30.0f);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if(Hitpoints <= 0)
        {
            GetComponent<Animator>().Play("Die");
            Instantiate(reward, new Vector3(205, 203), Quaternion.identity);
            GameObject.FindGameObjectWithTag("portal_end_2").GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Gate"));
            GameObject.FindGameObjectWithTag("portal_start_2").SetActive(false);
        }
    }

}
