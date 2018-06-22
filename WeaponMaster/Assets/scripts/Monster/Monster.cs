using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public ItemBox itembox;
    public StatusBar Hpbar;
    public GameObject RsMonster;
    public Transform RsPos;
    public float atk = 10;
    public float def = 2;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 50;
    public float dmg;
    public float power = 50.0f;
    public float m_fSpeed = 10.0f;
    public float m_fPower;
    public Rigidbody monster;
   public bool isDie = false;
    public float accumulator = 0.0f;
    public int Resetdone = 0;
    public float Reset = 0.2f;
    public int hit = 0;


    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (hit == 1)
        { accumulator += Time.deltaTime; }
        
        if (accumulator >= Reset)
        {
            Resetdone= 1;
            accumulator = 0.0f;
        }
        if (Resetdone == 1)
        {
            monster.isKinematic = true;
            Resetdone = 0;
            hit = 0;
        }
        if (monster.isKinematic == true)
        {
            monster.isKinematic = false;
        }


        Hpbar.Set(hp, hpmax);
        if (hp <= 0)
        {
            isDie = true;
        }
        Dead();

        float v = Input.GetAxis("Vertical");
        if (v >= 0.1)
        {
            
        }
      
    }
    void Dead()
    {
        if (isDie == true)
        {
            Destroy(gameObject);
            GameManager.GetInstance().m_cPlayer.exp = GameManager.GetInstance().m_cPlayer.exp + exp;
            RespawnMonster();
            itembox.GiveItem(GameManager.GetInstance().m_cPlayer);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();


        if (collision.collider.tag == "Player")
        {
            rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);
            //dmg = collision.gameObject.GetComponent<Player>().atk - def;
            //if (dmg <= 0)
            //{
            //    dmg = 0;
            //}
            //hp = hp - dmg;
            hit = 1;
           
        }

        else if (collision.collider.tag == "Wall")
        {
            monster.isKinematic = true;
        }
        else if (collision.collider.tag == "Monster")
        { 
            hit = 1;
        }

    }
    void RespawnMonster()
    {
        GameObject objGame = Instantiate(RsMonster, RsPos.position, RsPos.rotation);
       Monster monster = objGame.GetComponent<Monster>();
        monster.RsMonster = RsMonster;
        monster.RsPos = RsPos;
        
    }

   
}
