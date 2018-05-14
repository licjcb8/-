using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {
    public RectTransform m_cRectTransform;
    float m_fMax;
	// Use this for initialization
	void Start () {
        m_cRectTransform = this.gameObject.GetComponent<RectTransform>();
        m_fMax = m_cRectTransform.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,10),""))
        {
            Set(10,100);
        }
    }

    public void Set(float cur, float max)
    {
        float fVal = cur / max;

        float fStatusBar = m_fMax * fVal;

        m_cRectTransform.sizeDelta = new Vector3(fStatusBar, m_cRectTransform.sizeDelta.y);
    }
}
