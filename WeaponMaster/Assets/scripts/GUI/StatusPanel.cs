using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour {
    public Text m_cText;
    // Use this for initialization

    public void Set(Player.eStatus status)
    {
        CharacterStatus cStatus = GameManager.GetInstance().m_cPlayer.GetStatus(status);
        m_cText.text = cStatus.Name;
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,40,100,20),"StatusPanel"))
        {
            Set(Player.eStatus.DMG);
        }
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
