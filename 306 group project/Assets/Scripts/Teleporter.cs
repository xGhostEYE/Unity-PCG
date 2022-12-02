using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter : MonoBehaviour{
    // Update is called once per frame
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_start_1"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_end_1").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_end_1"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_start_1").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_start_2"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_end_2").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_end_2"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_start_2").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_boss_start"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_boss_end").transform.position;
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "portal_boss_end"){
            collision.gameObject.transform.position =  GameObject.FindGameObjectWithTag("portal_boss_start").transform.position;
        }
    }
}
