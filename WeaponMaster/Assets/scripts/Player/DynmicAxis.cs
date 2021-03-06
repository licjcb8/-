﻿using UnityEngine;
using System.Collections;

public class DynmicAxis : MonoBehaviour
{




    public Animator animator;
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    public float m_fPower;

   void Start()
    {
      

    }

    void Update()
    {
 

    }

    int anistate=0;


    private void FixedUpdate()
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().AddForce(transform.forward * m_fSpeed);


        if (Mathf.Abs(fVertical) > 0 || Mathf.Abs(fHorizontal) > 0)
        {
            float fTranslation = fVertical * m_fSpeed;
            float fRotation = fHorizontal * m_fRotSpeed;
            fTranslation *= Time.deltaTime;
            fRotation *= Time.deltaTime;
            transform.Translate(0, 0, fTranslation);
            transform.Rotate(0, fRotation, 0);

        

        }
       
    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();

        if (collision.collider.tag == "Monster")
        { rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed); }
    }
}