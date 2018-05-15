using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPreset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<Monster>().hp = collision.gameObject.GetComponent<Monster>().hpmax;
        }
 
    }
}
