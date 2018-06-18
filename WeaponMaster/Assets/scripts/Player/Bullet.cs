using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletdmg;
    public float speed = 500.0f;
    // Use this for initialization
    void Start () {
       
        bulletdmg = GameManager.GetInstance().m_cPlayer.atk;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
   

    // Update is called once per frame
    void Update () {

	}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Monster")
    //    {
    //        collision.gameObject.GetComponent<Monster>().hp = collision.gameObject.GetComponent<Monster>().hp - bulletdmg;
    //        collision.gameObject.GetComponent<Monster>().hit = 1;
    //        Destroy(gameObject);
    //    }
    //    else if (collision.collider.tag == "Wall")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Monster")
        {
            Rigidbody rigidbodyTarget = other.gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Monster>().hp = other.gameObject.GetComponent<Monster>().hp - bulletdmg;
            other.gameObject.GetComponent<Monster>().hit = 1;
            rigidbodyTarget.AddForce(transform.forward * speed);
            Destroy(gameObject);
            
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
