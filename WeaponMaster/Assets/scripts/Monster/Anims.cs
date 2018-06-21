using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour {
    Animator animator;
    float moveHorizontal;
    float moveVertical;
    public bool isRunning = false;
    public bool isDamaged = false;


    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
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

        if (isDamaged == true)
        {
            animator.SetBool("isDamaged", true);
        }
        else
        {
            animator.SetBool("isDamaged", false);
        }
    }
   

}
