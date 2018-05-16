using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPanel : MonoBehaviour {
    public Image m_cImage;
    public Text m_cText;
    // Use this for initialization

    public void Set(ItemManager.eItem item)
    {
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        m_cImage.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
        m_cText.text = cItem.Comment;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 40, 100, 20), "GUIPanel"))
        {
            Set(ItemManager.eItem.ShortSword);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
