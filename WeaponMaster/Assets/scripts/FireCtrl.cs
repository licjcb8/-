﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {
    public GameObject bullet;
    public Transform firePos;
    public float fireRate;
    public float delay;
	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.GetInstance().m_cPlayer.Weapon == 1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                InvokeRepeating("Fire", delay, fireRate);
               // Fire();
            }
        }
    }

    void Fire()
    {
        CreateBullet();
    }
    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
