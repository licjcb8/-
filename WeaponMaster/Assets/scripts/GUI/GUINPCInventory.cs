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
  public int equalornot =1;

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

    public void BuyItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        player.SetInventory(item);
    }

    

    public void CombinateItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        //GameManager.GetInstance().m_cNPC.m_listBag.Sort();
        //cItem.m_needBag.Sort();
        //if (GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag.Count != GameManager.GetInstance().m_cNPC.m_listBag.Count)
        //{
        //    equalornot = 0;
        //}
        //for (int i = 0; i < GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag.Count; i++)
        //{
        //    ingredient = (ItemManager.eIngredient)i;
        //    if (GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag[i] != GameManager.GetInstance().m_cNPC.m_listBag[i])
        //    {
        //        equalornot = 0;
        //    }
        //}
        //if (equalornot == 1)
        //{
        //    player.SetInventory(item);

        //}
        //var firstNotSecond = GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag.Except(GameManager.GetInstance().m_cNPC.m_listBag).ToList();
        //var secondNotFirst = GameManager.GetInstance().m_cNPC.m_listBag.Except(GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag).ToList();
        ////!firstNotSecond.Any() && !secondNotFirst.Any()
        //if (!firstNotSecond.Any() && !secondNotFirst.Any())
        //{
        //    player.SetInventory(item);
        //}


        if (GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag.SequenceEqual(GameManager.GetInstance().m_cNPC.m_listBag))
        {
            player.SetInventory(item);
        }
        //{ }

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

