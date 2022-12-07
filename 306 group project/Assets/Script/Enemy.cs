using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 25f;
    [SerializeField] GameObject rewardEgg;
    [SerializeField] GameObject floatingPoint;

    // Start is called before the first frame update
    void Start()
    {
        health = PlayerInfo.Instance.damage* Random.Range(1.0f, 4.0f);
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        health-=damageAmount;

        GameObject dmg = Instantiate(floatingPoint, this.gameObject.transform.position + new Vector3(0, 0.2f), Quaternion.identity);
        dmg.transform.GetChild(0).GetComponent<TextMesh>().text = "-" + damageAmount;
        if (health <= 0)
        {
            if (Random.Range(0.0f, 1.0f) < 0.3)
            {
                Instantiate(rewardEgg,this.gameObject.transform.position,Quaternion.identity);
            }
           Destroy(gameObject);
        }
    }
}
