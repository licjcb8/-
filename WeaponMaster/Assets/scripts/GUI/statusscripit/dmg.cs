using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dmg : MonoBehaviour {
 
    public Text DMGText;
	// Use this for initialization
	void Start () {
        DMGText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        DMGText.text = "DMG : " + gameObject.GetComponent<Player>().dmg;
	}
}
