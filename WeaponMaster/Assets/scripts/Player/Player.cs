using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus
{
    string strStatusName;
    int nStatus;

    public string Name { get { return strStatusName; } }
    public int Status { get { return nStatus; } }

    public CharacterStatus(string Name, int Status)
    {
        Set(Name, Status);
    }

    public void Set(string Name, int Status)
    {
        Name = strStatusName;
        Status = nStatus;
    }

}

public class Player : MonoBehaviour {

    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();
    List<ItemManager.eItem> m_listEquipment = new List<ItemManager.eItem>();
    public List<ItemManager.eIngredient> m_listIngredient = new List<ItemManager.eIngredient>();
    List<CharacterStatus> m_listStatus = new List<CharacterStatus>();
    public StatusBar Hpbar;
    ItemManager.eItem item;
    public enum eStatus {  NONE = -1, DMG,DEF, HP, EXP, LV}
    public float atk = 20;
    public float def = 2;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 0;
    public int lv = 1;
    public float dmg;
    public GameObject DmgText;
    public int Weapon = 0;
    public int itemselect;
    public GameObject mainCamera;
    public float m_fMinDist = 3;
    public float m_fDist1 = 0;
    public float m_fDist2 = 0;
    public Transform m_Target1;
    public Transform m_Target2;
    public float accumulator = 0.0f;
    public int cooltimedone = 0;
    public float cooltime = 0.5f;


    public void Initialize()
    {
        m_listStatus.Add(new CharacterStatus("데미지", 20));
        m_listStatus.Add(new CharacterStatus("방어력", 2));
        m_listStatus.Add(new CharacterStatus("체력", 100));
        m_listStatus.Add(new CharacterStatus("경험치", 0));
        m_listStatus.Add(new CharacterStatus("레벨", 1));
    }

    public CharacterStatus GetStatus(eStatus status)
    {
        return m_listStatus[(int)status];
    }

    private void OnGUI()
    {
        for (int i = 0; i < m_listStatus.Count; i++)
        {
            GUI.Box(new Rect(Screen.width - 100, 20 * i, 100, 20), m_listStatus[i].Name);
        }
    }
    public void SetInventory(ItemManager.eItem item)
    {
        m_listInventory.Add(item);
    }

    public void SetIngredient(ItemManager.eIngredient ingredient)
    {
        m_listIngredient.Add(ingredient);
    }

  

    public void SetEquip()
    {

        ItemManager.eItem item = (ItemManager.eItem)itemselect;

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        itemselect = (int)item;
        m_listEquipment.Add(item);
    }
    public void SetEquipment()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
   
        if (cItem.fx == "atk")
        {
            atk = atk + cItem.stat;
        }

        else if (cItem.fx == "def")
        {
            def = def + cItem.stat;
        }
    }
    public ItemManager.eItem GetInventory(ItemManager.eItem item)
    {
        return m_listInventory.Find(obj => obj.Equals(item));
    }

    public ItemManager.eIngredient GetBag(ItemManager.eIngredient ingredient)
    {
        return m_listIngredient.Find(obj => obj.Equals(ingredient));
    }
    public ItemManager.eItem GetEquip(ItemManager.eItem item)
    {
        return m_listEquipment.Find(obj => obj.Equals(item));
    }

    public ItemManager.eItem GetInventory(int idx)
    {
        return m_listInventory[idx];
    }
    public ItemManager.eIngredient GetBag(int idx)
    {
        return m_listIngredient[idx];
    }
    public ItemManager.eItem GetEquip(int idx)
    {
        return m_listEquipment[idx];
    }

    public void DeleteInventory(ItemManager.eItem item)
    {
        m_listInventory.Remove(item);
    }

    public void DeleteBag(ItemManager.eIngredient ingredient)
    {
        m_listIngredient.Remove(ingredient);
    }

    public void DeleteEquip(ItemManager.eItem item)
    {
        m_listEquipment.Remove(item);
    }
    public int GetInventorySize()
    {
        return m_listInventory.Count;
    }

    public int GetBagSize()
    {
        return m_listIngredient.Count;
    }
    public int GetEquipSize()
    {
        return m_listEquipment.Count;
    }

    // Use this for initialization
    void Start () {

        DmgText = GameObject.Find("DMGText");

    }
    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.collider.tag == "Monster")
        {
            dmg = collision.gameObject.GetComponent<Monster>().atk - def;
            if (dmg <= 0)
            {
                dmg = 0;
            }
   hp = hp - dmg;
           
            if (collision.gameObject.GetComponent<Monster>().hp <= 0)
            {
               exp = exp + collision.gameObject.GetComponent<Monster>().exp;
            }

        }

        else if (collision.collider.tag == "HPReset")
        {
            hp = hpmax;
        }
       


    }

    // Update is called once per frame
    void Update () {

        if (cooltimedone == 0)
        {
            accumulator += Time.deltaTime;
            if (accumulator >= cooltime)
            {
                cooltimedone = 1;
                accumulator = 0.0f;
            }
        }
        if (cooltimedone == 1)
        {
            AttackMonster();
        }
        if (exp == 100)
        {
            LVUP();
        }
        Hpbar.Set(hp, hpmax);


    }
    public void LVUP()
    {
        exp = 0;
        lv++;
        Debug.Log("Level up!");
        atk = atk + 10;
        def = def + 2;
        hpmax = hpmax + 50;
        hp = hpmax;
    }
   public void SetWeapon(int i)
    {
        Weapon = i;
    }
    public void AttackMonster()
    {
        m_Target1 =GameManager.GetInstance().monster.transform;
        Vector3 vTargetPos1 = m_Target1.position;
        Vector3 vPos1 = transform.position;

        m_Target2 = GameManager.GetInstance().boss.transform;
        Vector3 vTargetPos2 = m_Target2.position;        Vector3 vPos2 = transform.position;

        m_fDist1 = Vector3.Distance(vTargetPos1, vPos1);
        m_fDist2 = Vector3.Distance(vTargetPos2, vPos2);
        if (Input.GetKeyUp(KeyCode.Z)) 
        {
            if (cooltimedone == 1)
            {
                if (m_fDist1 < m_fMinDist)
                {
                    GameManager.GetInstance().monster.hp = GameManager.GetInstance().monster.hp - dmg;
                    cooltimedone = 0;
                }
                else if (m_fDist2 < m_fMinDist)
                {
                    GameManager.GetInstance().boss.hp = GameManager.GetInstance().boss.hp - dmg;
                    cooltimedone = 0;
                }

            }
        }

    }

}
