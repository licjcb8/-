using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletdmg;
    public float speed = 500.0f;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        bulletdmg = GameManager.GetInstance().m_cPlayer.dmg;
    }
   

    // Update is called once per frame
    void Update () {

	}

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().hp = collision.gameObject.GetComponent<Monster>().hp - bulletdmg;
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
