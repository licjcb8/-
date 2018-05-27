using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public List<GameObject> m_listScene;
    public GUIInventory m_guiInventory;
    public enum eSceneStatus {TITLE, GAMEOVER, THEEND, INVENTORY,STATUS,PLAY, MAX};
    eSceneStatus m_eCurrentStatus;

    void SetInventory()
    {
        if (!m_guiInventory.gameObject.activeSelf)
        {
            m_guiInventory.SetInventory(GameManager.GetInstance().m_cPlayer);
            m_guiInventory.gameObject.SetActive(true);
        }
        else
        {
            m_guiInventory.gameObject.SetActive(false);
        }
    }

    public void SetStatus(eSceneStatus status)
    {
        switch (status)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.GAMEOVER:
                break;
            case eSceneStatus.THEEND:
                break;
            case eSceneStatus.INVENTORY:
                GUIInventory inventory = m_listScene[(int)eSceneStatus.INVENTORY].GetComponent<GUIInventory>();
                inventory.SetInventory(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.STATUS:
                break;
            case eSceneStatus.PLAY:
                break;
        }
        ShowScene(status);
        m_eCurrentStatus = status;
    }

    public void UpdateStatus()
    {
        switch (m_eCurrentStatus)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.GAMEOVER:
                break;
            case eSceneStatus.THEEND:
                break;
            case eSceneStatus.INVENTORY:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.STATUS:
                if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.PLAY:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.INVENTORY);
                }
                else if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.STATUS);
                }
                break;

        }
    }

    public GameObject GetScene(eSceneStatus status)
    {
        return m_listScene[(int)status];
    }

    public void ShowScene(eSceneStatus status)
    {
        for (eSceneStatus e = 0; e < eSceneStatus.MAX; e++)
        {
            if (status == e)
                m_listScene[(int)e].SetActive(true);
            else
                m_listScene[(int)e].SetActive(false);
        }
    }



    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
}
