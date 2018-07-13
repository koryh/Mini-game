using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectGenerator : MonoBehaviour {
    public int effectCodes = 0;
    public GameObject runningDust;
    public bool stepOnGround = false;
    private float timerRunDust = 0;

    private void Update()
    {
        timerRunDust += Time.fixedDeltaTime;
        if (stepOnGround && timerRunDust >= 0.5f)
        {
            stepOnGround = false;
            GameObject obj = runningOn(this.transform.position);
            obj.transform.Translate(new Vector3(-0.2f, -0.7f, 0));//Spawn position.
            Vector2 localScale = this.gameObject.transform.localScale;
            localScale.x = localScale.x * -1;
            obj.transform.localScale = localScale;
            timerRunDust = 0;
        }

    }

    GameObject runningOn(Vector3 position)
    {
        return Instantiate<GameObject>(runningDust, position, new Quaternion());
    }
}