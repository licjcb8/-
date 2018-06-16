using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {
    Animator animator;
   
    float moveHorizontal;
    float moveVertical;
    public int Attack = 0;
    bool isRunning = false;
    bool isDead = false;
    bool isAttacking = false;
    bool ismeele = false;
  

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveVertical = Input.GetAxis("Vertical");
        if (moveVertical != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GetComponent<Player>().Weapon==1)
            isAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GetComponent<Player>().Weapon == 0)
                ismeele = true;
        }
        else
        {
            isAttacking = false;
            ismeele = false;
          
        }
        AnimationUpdate();
	}
    void AnimationUpdate()
    {
        if (isRunning == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (isAttacking == true)
        {
            animator.SetBool("isAttacking", true);
          
        }
        else
        {
            animator.SetBool("isAttacking", false);

        }

        if (ismeele == true)
        {
            animator.SetBool("isMeele", true);
        }
        else
        {
            animator.SetBool("isMeele", false);

        }


        if (isDead == true)
        {
            animator.SetBool("isDead", true);
        }
        else
        {
            animator.SetBool("isDead", false);
        }
            
    }
}
