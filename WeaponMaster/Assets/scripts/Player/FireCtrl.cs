using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {
    public GameObject bullet;
    public Transform firePos;
    public float accumulator = 0.0f;
    public int cooltimedone = 0;
    public float cooltime = 0.2f;

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        
        if (cooltimedone==0)
        {
            accumulator += Time.deltaTime;
            if (accumulator >= cooltime)
            {
                cooltimedone = 1;
                accumulator = 0.0f;
            }
        }
        if (GameManager.GetInstance().m_cPlayer.Weapon == 1)
        {
            if (cooltimedone==1)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Fire();
                }
            }
        }
    }
    
   public void Fire()
    {
      
            CreateBullet();
        cooltimedone = 0;
      
      
    }
  

    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
