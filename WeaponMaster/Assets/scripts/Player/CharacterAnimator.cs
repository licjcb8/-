using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    public enum eAnimate { NONE = -1, Wait, Walk, Attack }
    public int cState = 0;
    Animator animator;

    public void SetState(int i )
    {
        cState = i;
    }
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        

        if (cState == 1)
        {
            animator.SetFloat("State", 1);
        }
	}
}
