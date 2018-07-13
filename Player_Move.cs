using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public int playerSpeed;
	private bool facingRight;
	public int PlayerjumpPower;
    private float moveX;
    private bool IsGrounded;
    public GameObject prefab;
    public bool Attacking;
    private bool PushingDown;


    private void Start()
    {
        playerSpeed = 10;
        facingRight = false;
        PlayerjumpPower = 1250;
        Attacking = false;
        PushingDown = false;

    }

    // Update is called once per frame
    void FixedUpdate () {
        PlayerMove ();

        if (Input.GetButtonDown("Down"))
        {
            GetComponent<Animator>().SetBool("isDowning", true);
            PushingDown = true;
        }
        else if (Input.GetButtonUp ("Down"))
        {
            GetComponent<Animator>().SetBool("isDowning", false);
            PushingDown = false;
        }
        PlayerBackJump();



        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
            Attacking = true;
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
            Attacking = false;
        }




    }




    void PlayerBackJump()
    {
        if (PushingDown && Input.GetButtonDown("Jump") && IsGrounded)
        {
            if (facingRight == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3000);
                Debug.Log("aaa");
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3000);
                Debug.Log("bbb");
            }

            
        }
    }

	void PlayerMove() {
	
		moveX = Input.GetAxis ("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded && !PushingDown) {
            Jump();
        }


        if (moveX != 0) {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		} 
		else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}	

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void Jump(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerjumpPower);
        IsGrounded = false;
        GetComponent<Animator>().SetBool("Jumping", true);
	}


	void FlipPlayer(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            GetComponent<Animator>().SetBool("Jumping", false);
        }
    }





}
