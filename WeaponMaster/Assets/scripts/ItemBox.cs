using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBox : MonoBehaviour {
    public ItemManager.eIngredient m_eIngredient;
    public void GiveItem(Player player)
    {
        player.SetIngredient(m_eIngredient);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
