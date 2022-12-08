using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float moveSpeed = 10f;

	Rigidbody2D rb;

	Player target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
        moveSpeed = Mathf.Max(PlayerInfo.Instance.LevelCounter * 15.0f, 15.0f);

        rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player>();
        Debug.Log("Target: " + target);
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		Destroy(gameObject);
	}
}
