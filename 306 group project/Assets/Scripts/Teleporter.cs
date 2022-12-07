using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter : MonoBehaviour{
    [SerializeField] GameObject gate;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_start_0")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_3").transform.position;
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_end_0")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_0").transform.position;
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_start_1")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_4").transform.position;
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_end_1")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_1").transform.position;
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_start_2")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_5").transform.position;
            GameObject.FindGameObjectWithTag("portal_end_2").GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(gate, new Vector3(203,202), Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("portal_end_2")){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_target_2").transform.position;
        }
    }
}
