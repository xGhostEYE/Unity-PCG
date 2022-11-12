using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] public GameObject Portal;
    [SerializeField] public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            StartCoroutine (teleportation());
        }
    }

    IEnumerator teleportation()
    {
        yield return new WaitForSeconds (0.5f);
        Player.transform.position = new Vector3 (Portal.transform.position.x, Portal.transform.position.y, Portal.transform.position.z);
    }
}


