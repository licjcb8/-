using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUINPCInventory : MonoBehaviour {

    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;

    public void SetInventory(NPC npc)
    {
        for (int i = 0; i < npc.GetInventorySize(); i++)
            m_cItemList.AddItem(npc.GetInventory(i), m_cPanel);
        m_cItemList.SetContextSize();
    }

    public void SetPanel(ItemManager.eItem item)
    {
        m_cPanel.Set(item);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

