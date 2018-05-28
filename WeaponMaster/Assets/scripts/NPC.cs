using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();

    // Use this for initialization
    public void Initialize()
    {
        m_listInventory.Add(ItemManager.eItem.ShortSword);
        m_listInventory.Add(ItemManager.eItem.Shield);
        m_listInventory.Add(ItemManager.eItem.Potion);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
