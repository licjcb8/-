﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIStatus : MonoBehaviour {
    List<GameObject> m_statuslist = new List<GameObject>();
    public GameObject m_prefabButton;
    public GameObject m_objContext;

    public void AddStat()
    {
        GameObject objButton = Instantiate(m_prefabButton);
        GUIItemButton cItemButton = objButton.GetComponent<GUIItemButton>();
        Button btnButton = objButton.GetComponent<Button>();

    }


    public void SetContextSize()
    {
        RectTransform rectContext = m_objContext.GetComponent<RectTransform>();
        GridLayoutGroup grid = m_objContext.GetComponent<GridLayoutGroup>();
        int nSize = 5;
        int nContextHeight = (int)(grid.cellSize.y * nSize);
        rectContext.sizeDelta = new Vector2(rectContext.sizeDelta.x, nContextHeight);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
