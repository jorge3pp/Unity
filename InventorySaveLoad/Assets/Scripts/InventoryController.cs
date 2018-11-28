﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public List<InventoryItem> Contents;
    public List<int> SpecificLootIDs;

    public bool PickLootRandomly = true;
    public bool HasRarityConstraint = false;
    public ItemRarity RarityConstraint = ItemRarity.Common;
    public int MaxItemCount = 10;

	// Use this for initialization
	void Start () {
        if (PickLootRandomly)
        {
            if (HasRarityConstraint)
            {
                PickItems(GameInstance.GetItemsOfRarity(RarityConstraint));
            }
            else
            {
                PickItems(GameInstance.MasterInventory.Items);
            }
        }
        else
        {
            if(SpecificLootIDs != null)
            {
                PickSpecificItems();
            }
        }
	}
	
    private void PickItems(List<InventoryItem> sourceList)
    {
        if (sourceList.Count > 0)
        {
            for(int i = 0; i < MaxItemCount; i++)
            {
                int index = UnityEngine.Random.Range(0, sourceList.Count - 1);
                Contents.Add(sourceList[index]);
            }
        }
    }

    private void PickSpecificItems()
    {
        foreach(var id in SpecificLootIDs)
        {
            InventoryItem item = GameInstance.GetInventoryItem(id);
            if(item!= null)
            {
                Contents.Add(item);
            }
        }
    }

}


[Serializable]
public enum ItemRarity
{
    Common,
    Rare,
    Legendary,
    Exotic
}

[Serializable]
public class InventoryItem
{
    public int ID;
    public int Quantity;
    public string Name;
    public string Description;
    public float Value;
    public float Weight;
    public ItemRarity Rarity;

}

[Serializable]
public class InventoryList
{
    public List<InventoryItem> Items;

    public InventoryList()
    {
        Items = new List<InventoryItem>();
    }

}