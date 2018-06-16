using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour {

    public int bulletdmg;
    public float speed = 500.0f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }


    // Update is called once per frame
    void Update()
    {
     
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().hp = collision.gameObject.GetComponent<Player>().hp - bulletdmg;
           
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
