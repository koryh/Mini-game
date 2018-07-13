using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour {
    public GameObject attach;
    public Effect runningDust;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void runningDustOn(Vector2 position)
    {
        generator(runningDust, position);
    }


    
    private void generator (Effect theEffect, Vector2 position)
    {
        Effect effect = (Effect)Instantiate(theEffect, new Vector3(attach.transform.position.x + attach.transform.localScale.x * position.x, attach.transform.position.y + position.y, 0), attach.transform.rotation);
        effect.gameObject.transform.localScale = attach.transform.localScale;

    }

    public void generator (Effect theEffect, Vector2 position, float direction)
    {
        Effect effect = (Effect)Instantiate(theEffect, new Vector3(attach.transform.position.x + attach.transform.localScale.x * position.x, attach.transform.position.y + position.y, 0),
            attach.transform.rotation);
        effect.gameObject.transform.localScale = attach.transform.localScale;
        effect.gameObject.transform.Rotate(0, 0, direction);
    }
}
