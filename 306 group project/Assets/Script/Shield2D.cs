using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("2D Collision!");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("2D Collision!");
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
        }
    }
}
