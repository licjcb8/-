using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {
    public GameObject m_Camera;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        LookCamera();
        
	}
    public void LookCamera()
    {
        m_Camera = GameManager.GetInstance().m_cPlayer.mainCamera;
        transform.LookAt(m_Camera.transform);
    }

}
