using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerAnimation : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;


    void Update()
    {

        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
         if (distance<4f){
            GetComponent<Animator>().Play("attackBoss");
         }
        faceUp();
    }

    void faceUp()
    {
        if (object1.transform.position.x > object2.transform.position.x)
        {
            //Move left
            float yRotation = 180.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
        else
        {
            //Move right
            float yRotation =0.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
    }

}
