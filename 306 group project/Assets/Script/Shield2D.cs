using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shield2D : MonoBehaviour
{
    public float minScale;
    public float maxScale;

    public float shieldTimer = 0f;

    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        shieldTimer = PlayerInfo.Instance.shieldSpeed;
        maxScale = PlayerInfo.Instance.shieldRange;


        if (transform.localScale == new Vector3(minScale,minScale,minScale))
        {
            Debug.LogWarning("1");
            transform.DOScale(new Vector3(maxScale, maxScale, maxScale), shieldTimer);
        }
        if (transform.localScale.x >= maxScale)
        {
            Debug.LogWarning("2");
            transform.DOScale(new Vector3(minScale, minScale, minScale), shieldTimer); 
        }
        

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
        if (col.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
    }

}
