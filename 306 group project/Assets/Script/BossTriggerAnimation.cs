using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerAnimation : MonoBehaviour
{
    private GameObject object1;
    private GameObject Boss;

    void Start()
    {
        object1 = GameObject.FindWithTag("Player");
        Boss = this.gameObject;
        Debug.Log(object1);
    }

    void Update()
    {

        float distance = Vector3.Distance(object1.transform.position, Boss.transform.position);
        if (distance < 4f)
        {
            GetComponent<Animator>().Play("attackBoss");
        }

        faceUp();
    }

    void faceUp()
    {
        if (object1.transform.position.x > Boss.transform.position.x)
        {
            //Move left
            float yRotation = 180.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
        else
        {
            //Move right
            float yRotation = 0.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
    }

}
