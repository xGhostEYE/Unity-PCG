using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    public GameObject acidPrefab;
    [SerializeField] private float spawnRate = 0.01f;
    private float spawnTimer;

    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        SpawnAcid();
        /* x = x + 10.0f;
        y = y + 10.0f;
        z = y + 10.0f;
        pos = new Vector3(x, y, z);
        transform.position = pos;*/
    }


    private void SpawnAcid() {

        if (Time.time > spawnTimer) {
            GameObject acid = Instantiate(acidPrefab, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
