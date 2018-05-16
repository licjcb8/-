using UnityEngine;
using System.Collections;

public class DynmicAxis : MonoBehaviour
{
  
    public StatusBar Hpbar;
    
 
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    public float m_fPower;
    public float dmg = 20;
    public float hpmax = 100;   
    public float hp =100;
    public int exp = 0;
    public int lv = 1;
    
    void Update()
    {
        if (exp == 100)
        {
            exp = 0;
            lv++;
            Debug.Log("Level up!");
        }
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
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();
        rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);

        if (collision.collider.tag == "Monster")
        {

            hp = hp - collision.gameObject.GetComponent<Monster>().dmg;
            if (collision.gameObject.GetComponent<Monster>().hp == 0)
            {
                Destroy(collision.gameObject);
                exp = exp + collision.gameObject.GetComponent<Monster>().exp;
            }

        }

        else if (collision.collider.tag == "HPReset")
        {
            hp = hpmax;
        }
        Hpbar.Set(hp, hpmax);


    }

   
}