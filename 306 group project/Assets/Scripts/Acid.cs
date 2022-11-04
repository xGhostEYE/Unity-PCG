using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float damageToPlayer = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if player falls into acid, it kills them
    //void OnTriggerStay(Collider other) {
        //if (other.transform.tag == "Player" && Time.time > damageTime) {
            //other.transform.GetComponent<Player>().TakeDamage(damageToPlayer);
        //}
    //}

}
