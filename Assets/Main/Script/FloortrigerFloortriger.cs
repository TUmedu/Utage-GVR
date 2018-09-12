using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloortrigerFloortriger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "寿司")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "寿司じゃないの")
        {
            Destroy(other.gameObject);
        }
    }
}
