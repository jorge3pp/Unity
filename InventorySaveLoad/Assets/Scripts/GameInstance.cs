using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameInstance : MonoBehaviour {

    private static InventoryList masterInventory;
    public static InventoryList MasterInventory { get { return masterInventory; } }
    private string InventoryListPath;

    public Profile UserProfile;
    public string savePath;

    private void Awake()
    {
        InventoryListPath = Application.streamingAssetsPath + "/inventory.json";
        LoadInventoryList();
    }
    
    public T Load<T>(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                return JsonUtility.FromJson<T>(json);
            }
        }
        else
        {
            return default(T);
        }
    }
    
    public void CreateProfile(string username)
    {
        UserProfile = new Profile(username);
        SaveUserProfile();
    }

    private void SaveUserProfile()
    {
        Save(UserProfile, savePath);
    }

    public void Save(object objectToSave, string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            string json = JsonUtility.ToJson(objectToSave,true);
            sw.Write(json);
        }
    }

    public void LoadInventoryList()
    {
        var items = Load<InventoryList>(InventoryListPath);
        if (items != null)
        {
            masterInventory = items;
        }
    }

    public static List<InventoryItem> GetItemsOfRarity(ItemRarity rarity)
    {
        return MasterInventory.Items.FindAll(item => item.Rarity == rarity);

    }

    public static InventoryItem GetInventoryItem(int ID)
    {
        return MasterInventory.Items.Find(item => item.ID == ID);

    }

}

