using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float damageToPlayer = 1000.0f;
    [SerializeField] private float riseSpeed = 0.5f;

    void Start()
    {
        riseSpeed = Mathf.Max(Mathf.Min(5.0f, PlayerInfo.Instance.LevelCounter/2.0f), 0.5f); // at least 0.5 at most 5.0f
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player") {
            other.transform.GetComponent<PlayerControl>().Kill();
        }
    }

}
