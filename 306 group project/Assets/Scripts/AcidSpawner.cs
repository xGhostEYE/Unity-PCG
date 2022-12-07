using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    public GameObject acidPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnAcid();
    }


    public void SpawnAcid() {

        for (int i = 0; i < 15; i++) {
            transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z);
            GameObject acid = Instantiate(acidPrefab, transform.position, transform.rotation);
        }

    }
}
