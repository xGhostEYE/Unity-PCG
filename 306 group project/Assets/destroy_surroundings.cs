using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_surroundings : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("touching it");
            Destroy(collision.gameObject);
        }
    }
}
