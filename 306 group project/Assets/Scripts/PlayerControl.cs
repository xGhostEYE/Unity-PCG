using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator playerAnima;

    private Rigidbody2D rg;

    private int jumpInt = 2;
    public GameObject deathEffect;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;

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
            jumpSound.Play();
            playerAnima.Play("PlayerJump");
            jumpInt -= 1;
            rg.AddForce(Vector3.up * PlayerInfo.Instance.jumpSpeed);
            // rg.AddForce(Vector2.up * PlayerInfo.Instance.jumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpInt != 0)
        {
            jumpSound.Play();
            playerAnima.Play("PlayerJump");
            jumpInt -= 1;
            rg.AddForce(Vector3.up * PlayerInfo.Instance.jumpSpeed);
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="ground")
        {
            jumpInt = 2;
        }
        if (collision.gameObject.tag == "Enemy" && PlayerInfo.Instance.hp > 0)
        {
            PlayerInfo.Instance.hp -= (20 + PlayerInfo.Instance.LevelCounter*5);
        }
        if (collision.gameObject.tag == "EnemyBullet" && PlayerInfo.Instance.hp > 0)
        {
            PlayerInfo.Instance.hp -= (5 + PlayerInfo.Instance.LevelCounter * 2);
        }

        if (collision.gameObject.tag == "BossMelee" && PlayerInfo.Instance.hp > 0)
        {
            PlayerInfo.Instance.hp -= (30 + PlayerInfo.Instance.LevelCounter * 5);
        }

        if (collision.gameObject.tag == "BossRange" && PlayerInfo.Instance.hp > 0)
        {
            PlayerInfo.Instance.hp -= (10 + PlayerInfo.Instance.LevelCounter * 5);
        }

        if (collision.gameObject.tag == "Exit")
        {
            GameManager.instance.NextLevel();
        }
    }

    public void TakeDamage (int d)
    {

    }

    public void Kill ()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        deathSound.Play();
        Destroy(effect, 1.0f);
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject, 0.5f);
        GameManager.instance.gameOver();
    }
}
