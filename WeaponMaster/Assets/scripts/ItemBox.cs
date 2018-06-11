using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
    public ItemManager.eItem m_eItem;

    public void GiveItem(Player player)
    {
        player.SetInventory(m_eItem);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
