using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public StatusBar Hpbar;
    public float dmg = 10;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 50;
    public float power = 50.0f;
    Rigidbody rb;
    
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            hp = hp - collision.gameObject.GetComponent<DynmicAxis>().dmg;
            Hpbar.Set(hp,hpmax);
            rb.AddForce(Vector3.forward * power);
        }
    }
}
