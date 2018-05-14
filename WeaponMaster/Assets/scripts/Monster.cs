using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public StatusBar Hpbar;
    public float dmg = 10;
    public float hpmax = 100;
    public float hp = 100;
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
            hp = hp - dmg;
         
            Hpbar.Set(hp,hpmax);
        }
    }
}
