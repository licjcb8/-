using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIStatus : MonoBehaviour {
    List<GameObject> m_statuslist = new List<GameObject>();
    public GameObject m_prefabButton;
    public GameObject m_objContext;

    public void AddStat(Player.eStatus status, StatusPanel cPanel)
    {
        CharacterStatus cStatus = GameManager.GetInstance().m_cPlayer.GetStatus(status);
        GameObject objButton = Instantiate(m_prefabButton);
        GUIItemButton cItemButton = objButton.GetComponent<GUIItemButton>();
        Button btnButton = objButton.GetComponent<Button>();
        btnButton.onClick.AddListener(() => cPanel.Set(status));
        cItemButton.m_cText.text = cStatus.Name;
        objButton.transform.SetParent(m_objContext.transform);
        m_statuslist.Add(objButton);

    }

    public void DeleteStatus(int idx)
    {
        GameObject button = m_statuslist[idx];
        m_statuslist.Remove(m_statuslist[idx]);
        Destroy(button);
    }

    public void ReleaseStatus()
    {
        for (int i = m_statuslist.Count - 1; i >= 0; i--)
            DeleteStatus(i);
        m_statuslist.Clear();
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
