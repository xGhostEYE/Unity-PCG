using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDetection : MonoBehaviour
{
    private GameObject nearestEnemy;
    public GameObject[] enemiesFound;
    [SerializeField] private AudioSource thankyouSound;
    private float oldDistance = 9999;

    // Start is called before the first frame update
    void Start()
    {
        enemiesFound = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemiesFound)
        {
            float dist = Vector2.Distance(this.gameObject.transform.position, enemy.transform.position);
            if (dist < oldDistance)
            {
                nearestEnemy = enemy;
                oldDistance = dist;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestEnemy == null) {
            enemyDeathHandler();
        }
    }

    void enemyDeathHandler() {
        // activate speech bubble ccanvas
        // give player randomized health points
        // melt away and say bye
        // destroy object
        Destroy(this.gameObject, 2.0f);
    }
}
