using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject Portal;
    private GameObject Player;
    public GameObject[] portalsFound;
    [SerializeField] private AudioSource portalSound;

    private float oldDistance = 9999;

    void Start() {
        portalsFound = GameObject.FindGameObjectsWithTag("PortalEnd");
        foreach (GameObject portalEnd in portalsFound)
        {
            float dist = Vector2.Distance(this.gameObject.transform.position, portalEnd.transform.position);
            if (dist < oldDistance)
            {
                Portal = portalEnd;
                oldDistance = dist;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Player = other.gameObject;
            StartCoroutine (teleportation());
            // GameManager.instance.NextLevel();
            portalSound.Play();
        }
    }

    IEnumerator teleportation()
    {
        yield return new WaitForSeconds (1.0f);
        Player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
    }
}


