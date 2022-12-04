using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject Portal;
    private GameObject Player;
    [SerializeField] private AudioSource portalSound;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Portal = transform.Find("PortalEnd").gameObject;
            Player = other.gameObject;
            StartCoroutine (teleportation());
            portalSound.Play();
        }
    }

    IEnumerator teleportation()
    {
        yield return new WaitForSeconds (1.0f);
        Player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
    }
}


