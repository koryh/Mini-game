using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;
    public int numOfEnemy = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (numOfEnemy < 3)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = -9;
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
                numOfEnemy += 1;
            }
        }
	}

    public void EnemyDown()
    {
        numOfEnemy -= 1;
    }
}
