using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator playerAnima;

    private Rigidbody2D rg;

    private int jumpInt = 2;
    public GameObject deathEffect;

    void Start()
    {
        playerAnima = GetComponent<Animator>();
        rg = transform.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-6.12f, 6.12f, 6.12f);
            transform.Translate(Vector2.left * PlayerInfo.Instance.moveSpeed * Time.deltaTime, Space.Self);

            playerAnima.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnima.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(6.12f, 6.12f, 6.12f);
            transform.Translate(Vector2.right * PlayerInfo.Instance.moveSpeed * Time.deltaTime, Space.Self);

            playerAnima.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnima.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpInt != 0)
        {
            playerAnima.Play("PlayerJump");
            jumpInt -= 1;
            rg.AddForce(Vector3.up * PlayerInfo.Instance.jumpSpeed);
        }
       
    }


    private void OnCollision2DEnter(Collision collision)
    {

        if (collision.gameObject.tag=="Ground")
        {
            jumpInt = 2;
        }
    }

    public void TakeDamage (int d)
    {

    }

    public void Kill ()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 1.0f);
        Destroy(this.gameObject);
        GameManager.instance.gameOver();
    }
}
