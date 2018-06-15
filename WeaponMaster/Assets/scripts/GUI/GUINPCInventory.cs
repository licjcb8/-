using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GUINPCInventory : MonoBehaviour {

    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;
    public Player player;
   
    ItemManager.eItem item;
    ItemManager.eIngredient ingredient;
    public int Check = 0;
  public int equalornot =0;

    public void SetInventory(NPC npc)
    {
        m_cItemList.ReleaseItems();
        for (int i = 0; i < npc.GetInventorySize(); i++)
            m_cItemList.AddCombination(npc.GetInventory(i), m_cPanel);
        m_cItemList.SetContextSize();
    }

    public void SetPanel(ItemManager.eItem item)
    {
        m_cPanel.Set(item);
    }

   

    

    public void CombinateItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        GameManager.GetInstance().m_cNPC.m_listBag.Sort();
        cItem.m_needBag.Sort();
        if (cItem.m_needBag.Count != GameManager.GetInstance().m_cNPC.m_listBag.Count)
        {
            equalornot = 0;
        }
        for (int i = 0; i < cItem.m_needBag.Count; i++)
        {
          
            //if (cItem.m_needBag[i].Name != GameManager.GetInstance().m_cNPC.GetBag(i).Name)
        }


        //{ player.SetInventory(item); }

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

