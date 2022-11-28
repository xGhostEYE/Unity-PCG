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
         if (distance<5f){
            GetComponent<Animator>().Play("attackBoss");
         }
    }

}
