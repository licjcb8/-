using UnityEngine;
using System.Collections;

public class DynmicAxis : MonoBehaviour
{




    public Animator animator;
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    public float m_fPower;

   void Start()
    {
        //animator = GetComponent<Animator>();

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

            //if (anistate != 1)
            //{
            //    animator.SetInteger("State", 1);
            //    anistate = 1;
            //}

        }
        //else
        //{
        //    if (anistate != 0)
        //    {
        //        animator.SetInteger("State", 0);
        //        anistate = 0;
        //    }
        //}
    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();


        switch (collision.gameObject.name)
        {
            case "Monster":
                rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);
                GameManager.GetInstance().Event(GameManager.eItemBox.MONSTER);
                break;
            case "Boss":
                rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);
                GameManager.GetInstance().Event(GameManager.eItemBox.BOSS);
                break;
           
        }

       

    }
}