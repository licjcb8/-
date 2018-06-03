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
            isAttacking = true;
            GetComponent<Player>().Attacstatus = 1;
        }

        else
        {
            isAttacking = false;
            GetComponent<Player>().Attacstatus = 0;
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
