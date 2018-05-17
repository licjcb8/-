using UnityEngine;
using System.Collections;

public class DynmicAxis : MonoBehaviour
{


   
    Animator animator;

    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    public float m_fPower;

   void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
 

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
     
    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();
        rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);

        switch (collision.gameObject.name)
        {
            case "Monster":
                GameManager.GetInstance().Event(GameManager.eItemBox.MONSTER);
                break;
            case "Boss":
                GameManager.GetInstance().Event(GameManager.eItemBox.BOSS);
                break;
        }

       

    }
}