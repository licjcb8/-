using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
   public Monster monster;
    public float bulletdmg;
    public float speed = 500.0f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        bulletdmg = monster.atk;
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.GetInstance().m_cPlayer.hp = GameManager.GetInstance().m_cPlayer.hp - bulletdmg;
            Destroy(gameObject);
            
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}