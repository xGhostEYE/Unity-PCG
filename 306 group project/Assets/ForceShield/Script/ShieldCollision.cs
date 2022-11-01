using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{

    public float hitTime = 0f;
    Material mat;

    void Start()
    {
        if (GetComponent<Renderer>())
        {
            mat = GetComponent<Renderer>().sharedMaterial;
        }

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            //敌人收到伤害，伤害为PlayerInfo玩家当前伤害值

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            //如果护盾碰到的是敌人扔出的道具，直接销毁道具。对玩家无效
            Destroy(collision.gameObject);
        }
    }
}

