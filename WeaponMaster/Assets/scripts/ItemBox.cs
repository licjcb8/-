using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
    public ItemManager.eItem m_eItem;

    public virtual bool CheckEvent(Player player)
    {
        if (m_eItem != ItemManager.eItem.NONE)
        {
            player.SetIventory(m_eItem);
            m_eItem = ItemManager.eItem.NONE;
            return true;
        }
        return false;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
