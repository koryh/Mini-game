using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    public int distance;
    public bool ground = false;
    public bool IsGrounded;

	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        if (IsGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
            distance += EnemySpeed;
        }
        if (distance > 200.0f)
        {
            Flip();
            distance = 0;
        }

        if (hit != null && hit.collider != null && hit.distance <0.7f && hit.collider.tag == "Ground")
        {
            Debug.Log("asd");
            ground = true;
        }
	}

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
}
