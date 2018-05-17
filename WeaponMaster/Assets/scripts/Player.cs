﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();
    public StatusBar Hpbar;
    public float dmg = 20;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 0;
    public int lv = 1;
    

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
       
      

    }
    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.collider.tag == "Monster")
        {

   hp = hp - collision.gameObject.GetComponent<Monster>().dmg;
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
    private void OnGUI()
    {
        for(int i=0; i<m_listInventory.Count; i++)
        {
            GUI.Box(new Rect(0, 20 * i, 100, 20), "" + m_listInventory[i]);
        }
    }
    // Update is called once per frame
    void Update () {
        
        if (exp == 100)
        {
            exp = 0;
            lv++;
            Debug.Log("Level up!");
        }
    }
}
