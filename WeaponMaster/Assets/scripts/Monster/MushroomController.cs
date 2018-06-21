using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour {
    public AnimationClip idle;
    public AnimationClip Run;
    public AnimationClip Damage;

    private Animation anim = null;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        anim.clip = idle;
        anim.Play();
	}

    // Update is called once per frame
    void Update() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v > 0 || h > 0) ;
        {
            anim.CrossFade(Run.name, 0.3f);
        }
	}
    public void OncollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = collision.gameObject.GetComponent<Rigidbody>();

        if (collision.collider.tag == "Player")
        {
            anim.CrossFade(Damage.name, 0.3f);
        }
 
    }
}
