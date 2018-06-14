using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class GUIManager : MonoBehaviour {

    public List<GameObject> m_listScene;
  
    public GUIInventory m_guiInventory;
    ItemManager.eIngredient ingredient;
    public NPC npc;
    public Player player;
    public GUINPCInventory m_guiNPCInventory;
    public MouseClick NPC;
    public int Selection = 0;
    public enum eSceneStatus {TITLE, GAMEOVER, THEEND, INVENTORY,STATUS,SHOP,BUY,SELL,PLAY, BAG,MAX};
    eSceneStatus m_eCurrentStatus;
    ItemManager.eItem item;
    
    void SetInventory()
    {
        if (!m_guiInventory.gameObject.activeSelf)
        {
            m_guiInventory.SetInventory(GameManager.GetInstance().m_cPlayer);
            m_guiInventory.gameObject.SetActive(true);
        }
        else
        {
            m_guiInventory.gameObject.SetActive(false);
        }
    }

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
                GUIInventory inventory = m_listScene[(int)eSceneStatus.INVENTORY].GetComponent<GUIInventory>();
                inventory.SetInventory(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.STATUS:
                break;
            case eSceneStatus.SHOP:
                break;
            case eSceneStatus.BUY:
                GUINPCInventory NPCInventory = m_listScene[(int)eSceneStatus.BUY].GetComponent<GUINPCInventory>();
                NPCInventory.SetInventory(GameManager.GetInstance().m_cNPC);
                break;
            case eSceneStatus.SELL:
                GUIBag bag1 = m_listScene[(int)eSceneStatus.SELL].GetComponent<GUIBag>();
                bag1.SetBag(GameManager.GetInstance().m_cPlayer);
                GUINPCBag bag2 = m_listScene[(int)eSceneStatus.SELL].GetComponent<GUINPCBag>();
                bag2.SetNPCBag(GameManager.GetInstance().m_cNPC);
                GUINPCInventory NPCInventory2 = m_listScene[(int)eSceneStatus.SELL].GetComponent<GUINPCInventory>();
                NPCInventory2.SetInventory(GameManager.GetInstance().m_cNPC);
                break;
       
            case eSceneStatus.PLAY:
                break;
            case eSceneStatus.BAG:
                GUIBag bag = m_listScene[(int)eSceneStatus.BAG].GetComponent<GUIBag>();
                bag.SetBag(GameManager.GetInstance().m_cPlayer);
                break;
        }
        ShowScene(status);
        m_eCurrentStatus = status;
    }

    public void UpdateStatus()
    {
        switch (m_eCurrentStatus)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.GAMEOVER:
                break;
            case eSceneStatus.THEEND:
                break;
            case eSceneStatus.INVENTORY:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.STATUS:
                if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.SHOP:
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                    NPC.A = 0;
                }
                if (Selection == 1)
                {
                    SetStatus(GUIManager.eSceneStatus.BUY);
                }
                if (Selection == 2)
                {
                    SetStatus(GUIManager.eSceneStatus.SELL);
                }
                break;
            case eSceneStatus.BUY:
                if(Selection == 0)
                {
                    SetStatus(GUIManager.eSceneStatus.SHOP);
                }
                break;
            case eSceneStatus.SELL:
                if (Selection == 0)
                {
                    SetStatus(GUIManager.eSceneStatus.SHOP);
                }
                break;
            case eSceneStatus.PLAY:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.INVENTORY);
                }
                else if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.STATUS);
                }
                else if (Input.GetKeyUp(KeyCode.O))
                {
                    SetStatus(GUIManager.eSceneStatus.BAG);
                }
                else if (NPC.A == 1)
                {
                    SetStatus(GUIManager.eSceneStatus.SHOP);

                }
                break;
            case eSceneStatus.BAG:
                if (Input.GetKeyUp(KeyCode.O))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;

        }
    }

    public GameObject GetScene(eSceneStatus status)
    {
        return m_listScene[(int)status];
    }

    public void ShowScene(eSceneStatus status)
    {
        for (eSceneStatus e = 0; e < eSceneStatus.MAX; e++)
        {
            if (status == e)
                m_listScene[(int)e].SetActive(true);
            else
                m_listScene[(int)e].SetActive(false);
        }
    }

    public void SetBUY()
    {
        Selection = 1;
    }
    public void SetSell()
    {
        Selection = 2;
    }
    public void GoBackShop()
    {
        Selection = 0;
    }

    public void InputItem()
    {
        ingredient = (ItemManager.eIngredient)GameManager.GetInstance().m_cItemManager.ingredientselect;
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        npc.SetBag(ingredient);
        player.DeleteBag(ingredient);
        SetStatus(eSceneStatus.SELL);
    }

    public void OutputItem()
    {
        ingredient = (ItemManager.eIngredient)GameManager.GetInstance().m_cItemManager.ingredientselect;
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        npc.DeleteBag(ingredient);
        player.SetIngredient(ingredient);
        SetStatus(eSceneStatus.SELL);
    }

    public void CombinateItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
       
        //GameManager.GetInstance().m_cNPC.m_listBag.Sort();
        //GameManager.GetInstance().m_cItemManager.m_listItems[GameManager.GetInstance().m_cItemManager.itemselect].m_needBag.Sort();
        //if (GameManager.GetInstance().m_cNPC.m_listBag.Contains(GameManager.GetInstance().m_cItemManager.m_listItems[GameManager.GetInstance().m_cItemManager.itemselect].m_needBag))
        //{ player.SetInventory(item); }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
}
