﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {
    public Camera m_cCamera;
   
    public int A = 0;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = m_cCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            float fDistance = 100;
            if(Physics.Raycast(ray, out hitInfo, fDistance))
            {
                if(hitInfo.collider)
                {
                    switch (hitInfo.collider.gameObject.name)
                    {
                        case "NPC":
                          
                            A = 1;
                            break;
                    }
                    Debug.Log("Ray:" + hitInfo.collider.gameObject.name);
                }
            }
        }
    }



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
