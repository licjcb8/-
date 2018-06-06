using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();

    // Use this for initialization
    public void SetIventory()
    {
        m_listInventory.Add(ItemManager.eItem.ShortSword);
        m_listInventory.Add(ItemManager.eItem.Shield);
        m_listInventory.Add(ItemManager.eItem.Bowgun);
        m_listInventory.Add(ItemManager.eItem.Potion);
    }
    public ItemManager.eItem GetInventory(ItemManager.eItem item)
    {
        return m_listInventory.Find(obj => obj.Equals(item));
    }

    public ItemManager.eItem GetInventory(int idx)
    {
        return m_listInventory[idx];
    }
    public void DeleteInvetory(ItemManager.eItem item)
    {
        m_listInventory.Remove(item);
    }
    public int GetInventorySize()
    {
        return m_listInventory.Count;
    }
    void Start () {
        SetIventory();
    }
	
	// Update is called once per frame
	void Update () {
     
	}
}
