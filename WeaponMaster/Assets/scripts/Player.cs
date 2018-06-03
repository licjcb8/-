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
    List<CharacterStatus> m_listStatus = new List<CharacterStatus>();
    public StatusBar Hpbar;
    public enum eStatus {  NONE = -1, DMG, HP, EXP, LV}
    public float dmg = 20;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 0;
    public int lv = 1;
    public GameObject DmgText;
    public int Attacstatus = 0;

    public void Initialize()
    {
        m_listStatus.Add(new CharacterStatus("데미지", 20));
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
    public void SetIventory(ItemManager.eItem item)
    {
        m_listInventory.Add(item);
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

    // Use this for initialization
    void Start () {

        DmgText = GameObject.Find("DMGText");

    }
    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.collider.tag == "Monster")
        {

   hp = hp - collision.gameObject.GetComponent<Monster>().dmg;
            if (Attacstatus == 1)
            {
                hp = hp + collision.gameObject.GetComponent<Monster>().dmg;
            }
            if (collision.gameObject.GetComponent<Monster>().hp == 0)
            {
                
                Destroy(collision.gameObject);
                
               exp = exp + collision.gameObject.GetComponent<Monster>().exp;
            }

        }

        else if (collision.collider.tag == "HPReset")
        {
            hp = hpmax;
        }
        Hpbar.Set(hp, hpmax);


    }

    // Update is called once per frame
    void Update () {
        
        if (exp == 100)
        {
            exp = 0;
            lv++;
            Debug.Log("Level up!");
            dmg = dmg + 10;
            hpmax = hpmax + 50;
            hp = hpmax;
        }
    }
}
