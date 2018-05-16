using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Player m_cPlayer;
    public List<ItemBox> m_listItemBoxes;
    public ItemManager m_cItemManager;
    public GUIManager m_cGUIManager;
    public GUIManager.eSceneStatus m_eSceneStatus;
    public enum eItemBox {MONSTER,BOSS,NPC }

    static GameManager m_cInstance;
    static public GameManager GetInstance()
    {
        return m_cInstance;
    }
    // Use this for initialization
    void Start() {
        m_cInstance = this;
        m_cGUIManager.SetStatus(m_eSceneStatus);
    }

    public void EventStart()
    {
    
        m_cGUIManager.SetStatus(GUIManager.eSceneStatus.PLAY);
    }

    public void EventExit()
    {
        Application.Quit();
    }

    public void EventTheEnd()
    {
        m_cGUIManager.SetStatus(GUIManager.eSceneStatus.THEEND);
    }

    public void EventGameOver()
    {
        m_cGUIManager.SetStatus(GUIManager.eSceneStatus.GAMEOVER);
    }


	// Update is called once per frame
	void Update () {
		
	}
    public void Event(eItemBox item)
    {
        switch (item)
        {
            case eItemBox.MONSTER:
                m_listItemBoxes[(int)item].CheckEvent(m_cPlayer);
                break;
            case eItemBox.BOSS:
                m_listItemBoxes[(int)item].CheckEvent(m_cPlayer);
                break;
            case eItemBox.NPC:
                m_listItemBoxes[(int)item].CheckEvent(m_cPlayer);
                break;
        }
    }
}
