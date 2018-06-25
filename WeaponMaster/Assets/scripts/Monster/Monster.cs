using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    public ItemBox itembox;
    public StatusBar Hpbar;
    public Transform DeathPos;
    public Transform RespawnPos;
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
    public float accumulator2 = 0.0f;
    public float Respawn = 3.0f;
    public int RespawnDone = 0;
    public int Resetdone = 0;
    public float Reset = 0.2f;
    public int hit = 0;
    

    // Use this for initialization
    void Start () {
      
	}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(DeathPos.transform.position, 10);
    }
        // Update is called once per frame
        void Update () {
        if (hit == 1)
        { accumulator += Time.deltaTime; }
        if (RespawnDone == 1)
        {
            accumulator2 += Time.deltaTime;
        }
        if (accumulator2 >= Respawn)
        {
            transform.position = RespawnPos.transform.position;
            RespawnDone = 0;
            accumulator2 = 0.0f;
            GetComponent<NavMeshAgent>().enabled = true;
        }

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
            isDie = false;
            monster.isKinematic = true;
            GetComponent<NavMeshAgent>().enabled = false;
            hp = hpmax;
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
        transform.position = DeathPos.transform.position;
        
        RespawnDone = 1;
        
    }

   
}
