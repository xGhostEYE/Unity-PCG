using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * riseSpeed * Time.deltaTime;
    }

    // if player falls into acid, it kills them
    void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            other.transform.GetComponent<PlayerControl>().Kill();
        }
    }

}
