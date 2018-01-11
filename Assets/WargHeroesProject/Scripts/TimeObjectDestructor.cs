using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectDestructor : MonoBehaviour {

    public float timeOut = 1.0f;
    public bool detachChildren = false;

	// Use this for initialization
	void Awake () {
        Invoke("DestroyNow", timeOut);
	}
	
	// Update is called once per frame
	void DestroyNow () {
        if (detachChildren)
        {
            transform.DetachChildren();
        }

        Destroy(gameObject);
	}
}
