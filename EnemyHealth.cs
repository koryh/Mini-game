using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public int EnemyHP = 3;
    Player_Move c2;
    EnemySpawner c1;

    // Use this for initialization
    void Start () {
        c2 = GameObject.Find("player").GetComponent<Player_Move>();
        c1 = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerRaycast();
        if (EnemyHP == 0)
        {
            Destroy(this.gameObject);
            c1.EnemyDown();
        }
	}



    void PlayerRaycast()
    {
        RaycastHit2D LeftHit = Physics2D.Raycast(transform.position, Vector2.left);
        RaycastHit2D RightHit = Physics2D.Raycast(transform.position, Vector2.right);
        if (LeftHit != null && LeftHit.collider != null && LeftHit.distance < 1f && LeftHit.collider.tag == "Player" && c2.Attacking==true)
        {
            EnemyHP -= 1;
            Debug.Log(EnemyHP);
        }
        else if(RightHit != null && RightHit.collider != null && RightHit.distance < 1f && RightHit.collider.tag == "Player" && c2.Attacking == true)
        {
            EnemyHP -= 1;
            Debug.Log(EnemyHP);
        }
    }

}
