using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMagnet : MonoBehaviour
{
    // egg magnet should be a child of the player
    void OnTriggerStay(Collider other){
        // check for collision with a egg, then tell egg to move to player
        if (other.gameObject.TryGetComponent<Egg>(out Egg egg)) {
            coin.ShowPlayerPos(transform.parent.position);
        }
    }

}
