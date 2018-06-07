using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string strName;
    string strComment;
    string strImage;
    int nStat;
    string strFx;

    public string Name { get { return strName; } }
    public string Comment { get { return strComment; } }
    public string Image { get { return strImage; } }
    public int stat { get { return nStat; } }
    public string fx { get { return strFx; } }

    public Item(string name, string comment, string img, int stat, string fx)
    {
        Set(name, comment, img,stat,fx);
    }

    public void Set(string name, string comment, string img,int stat,string fx)
    {
        strName = name;
        strComment = comment;
        strImage = img;
        nStat = stat;
        strFx = fx;
    }

}

public class ItemManager: MonoBehaviour {
    public enum eItem { NONE= -1, ShortSword, Shield, Bowgun,Potion, Slime, Skeleton,Setting}
    List<Item> m_listItems = new List<Item>();
    public int itemselect;
    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize()
    {
        m_listItems.Add(new Item("숏소드", "매우 허접한 숏소드, 공격력 +10", "ShortSword",10,"atk"));
        m_listItems.Add(new Item("쉴드", "매우 허접한 쉴드, 방어력 +10", "Shield",10,"def"));
        m_listItems.Add(new Item("보우건", "매우 허접한 보우건, 공격럭 +10", "Bowgun", 10, "atk"));
        m_listItems.Add(new Item("포션", "빨간포션, 체력 +20", "Potion",10,"hp"));
        m_listItems.Add(new Item("슬라임액체", "슬라임을 잡다보면 획득할 수 있다, 잡템", "Slime",0,"etc"));
        m_listItems.Add(new Item("스켈레톤의 골반뼈", "스켈레톤의 부러진 골반뼈인 듯 하다, 잡템", "Skeleton",0,"etc"));
        m_listItems.Add(new Item("없음", "없음", "Slime", 0, "etc"));

    }

    public Item GetItem(eItem item)
    {
        return m_listItems[(int)item];
    }
 
    private void OnGUI()
    {
        for (int i = 0; i < m_listItems.Count; i++)
        {
            GUI.Box(new Rect(Screen.width - 100, 20 * i, 100, 20), m_listItems[i].Name);
        }
    }
}
