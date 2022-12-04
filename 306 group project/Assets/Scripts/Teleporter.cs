using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter : MonoBehaviour{
    // Update is called once per frame
    void OnCollisionEnter(Collision collision){
        Debug.Log("here now");
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_start_0"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_end_0").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_end_0"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_start_0").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_start_1"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_end_1").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_end_1"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_start_1").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_start_3"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_end_3").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_end_3"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_start_3").transform.position;
        }
    }
}
