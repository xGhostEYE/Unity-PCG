using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float damageToPlayer = 1000.0f;
    [SerializeField] private float riseSpeed = 0.5f;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * riseSpeed * Time.deltaTime;
    }

    void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            other.transform.GetComponent<PlayerControl>().Kill();
        }
    }

}
