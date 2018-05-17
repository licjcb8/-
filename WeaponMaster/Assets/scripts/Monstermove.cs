using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstermove : MonoBehaviour {
    public float m_fSpeed = 10.0f;
    public float m_fRotSpeed = 100.0F;

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
}
