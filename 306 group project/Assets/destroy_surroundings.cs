using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_surroundings : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Destroy(collision.gameObject);
        }
    }
}
