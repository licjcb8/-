using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string strName;
    string strComment;
    string strImage;

    public string Name { get { return strName; } }
    public string Comment { get { return strComment; } }
    public string Image { get { return strImage; } }

    public Item(string name, string comment, string img)
    {
        Set(name, comment, img);
    }

    public void Set(string name, string comment, string img)
    {
        strName = name;
        strComment = comment;
        strImage = img;
    }

}

public class ItemManager: MonoBehaviour {
    public enum eItem { NONE= -1, ShortSword, Shield, Potion, Slime, Skeleton}
    List<Item> m_listItems = new List<Item>();
	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize()
    {
        m_listItems.Add(new Item("숏소드", "매우 허접한 숏소드, 공격력 +10", "ShortSword"));
        m_listItems.Add(new Item("쉴드", "매우 허접한 쉴드, 방어력 +10", "Shield"));
        m_listItems.Add(new Item("포션", "빨간포션, 체력 +20", "Potion"));
        m_listItems.Add(new Item("슬라임액체", "슬라임을 잡다보면 획득할 수 있다, 잡템", "Slime"));
        m_listItems.Add(new Item("스켈레톤의 골반뼈", "스켈레톤의 부러진 골반뼈인 듯 하다, 잡템", "Skeleton"));
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
