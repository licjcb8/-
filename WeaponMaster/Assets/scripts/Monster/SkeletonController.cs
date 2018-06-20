using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {
    Animator animator;

    float moveHorizontal;
    float moveVertical;
    bool isRunning = false;
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
        if (moveVertical != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
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
    }

}
