using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    Rigidbody rb;
    bool flyToPlayer = false;
    Vector3 playerPos;
    float moveSpeed = 10.0f;

    [SerializeField] private AudioSource collectSound;

    // get reference during load
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        // if the egg is within players egg magnet, move to player
        
        if (flyToPlayer) {
            Vector3 playerDirection = (playerPos - transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * moveSpeed;
            flyToPlayer = false;
        } else {
            //rb.velocity = Vector2.zero;
        }
    }

    public void ShowPlayerPos(Vector3 position) {
        playerPos = position;
        flyToPlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            collectSound.Play();
            PlayerInfo.Instance.jumpSpeed *= 1.1f;
            Destroy(this.gameObject, 0.3f);
        }
    }

}
