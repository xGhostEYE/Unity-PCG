using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shield2D : MonoBehaviour
{
    public float minScale;
    public float maxScale;

    public float timer = 0f;

    void Start()
    {
        //shield shrink animation
        timer = PlayerInfo.Instance.shieldSpeed;
        maxScale = PlayerInfo.Instance.shieldRange;

        Sequence sequence = DOTween.Sequence();
        //add wanted animation into the queue
        sequence.Append(transform.DOScale(new Vector3(maxScale, maxScale, maxScale), timer));//bigger scale
        //sequence.AppendInterval(1);
        sequence.Append(transform.DOScale(new Vector3(minScale, minScale, minScale), timer));//smaller scale                                                                              //这个队列循环播放
        sequence.SetLoops(-1);
    }

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
