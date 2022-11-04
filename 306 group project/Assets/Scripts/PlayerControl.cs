using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator playerAnima;

    private Rigidbody rg;

    private int jumpInt = 2;

    void Start()
    {
        playerAnima = GetComponent<Animator>();
        rg = transform.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, -90f, 0);
            transform.Translate(Vector3.forward * PlayerInfo.Instance.moveSpeed * Time.deltaTime, Space.Self);

            playerAnima.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnima.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 90f, 0);
            transform.Translate(Vector3.forward * PlayerInfo.Instance.moveSpeed * Time.deltaTime, Space.Self);

            playerAnima.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnima.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpInt != 0)
        {
            jumpInt -= 1;
            rg.AddForce(Vector3.up * PlayerInfo.Instance.jumpSpeed);
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Box!");

        if (collision.gameObject.tag=="Ground")
        {
            jumpInt = 2;
            Debug.Log("Ground!");
        }
    }

}
