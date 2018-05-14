using UnityEngine;
using System.Collections;

public class DynmicAxis : MonoBehaviour
{
    public StatusBar Hpbar;
    
 
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    public float dmg = 20;
    public float hpmax = 100;   
    public float hp =100;


    void Update()
    {
        //float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);
    }

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

        GUI.Box(new Rect(0, 0, 300, 100),
                "Vertical:" + fVertical +
                "\nHorizontal:" + fHorizontal);
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            hp = hp - gameObject.GetComponent<Monster>(dmg);
            if (hp == 0)
            { Destroy(collision.gameObject); }
            
        }
        Hpbar.Set(hp, hpmax);
    }

}