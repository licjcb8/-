using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
   
    public StatusBar Hpbar;
    public GameObject RsMonster;
    public Transform RsPos;
    public float dmg = 10;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 50;
    public float power = 50.0f;
    public float m_fSpeed = 10.0f;
    public float m_fPower;
    public Rigidbody monster;
   public bool isDie = false;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Hpbar.Set(hp, hpmax);
        if (hp <= 0)
        {
            isDie = true;
        }
        Dead();
    }
    void Dead()
    {
        if (isDie == true)
        {
            Destroy(gameObject);
            GameManager.GetInstance().m_cPlayer.exp = GameManager.GetInstance().m_cPlayer.exp + exp;
            //RespawnMonster();
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();


        if (collision.collider.tag == "Player")
        {
            rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);

            hp = hp - collision.gameObject.GetComponent<Player>().dmg;
           
          

        }
      
        else if (collision.collider.tag == "Wall")
        {

            monster.isKinematic = true;
           
        }
        if (monster.isKinematic == true)
        {
            monster.isKinematic = false;
        }


    }
    void RespawnMonster()
    {
        Instantiate(RsMonster, RsPos.position, RsPos.rotation);
        
    }

   
}
