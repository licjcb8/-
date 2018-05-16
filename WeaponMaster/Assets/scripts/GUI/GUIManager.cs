using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
    public enum eSceneStatus {TITLE, GAMEOVER, THEEND, INVENTORY, STATUS ,PLAY, MAX};
    eSceneStatus m_eCurrentStatus;

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
                //GUIIventory iventory = m_listScene[(int)eSceneStatus.INVENTORY].GetComponent<GUIIventory>();
                //iventory.SetIventory(GameManager.GetInstence().m_cPlayer);
                break;
            case eSceneStatus.PLAY:
                GameManager.GetInstence().ResetTime();
                break;
        }

    }




    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
