using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameInstance : MonoBehaviour {

    public Profile UserProfile;
    private string savePath;

	// Use this for initialization
	void Start () {
        savePath = Application.persistentDataPath + "\\profile.sav";
        DontDestroyOnLoad(this);
	}
	
    public void CreateProfile(string username)
    {
        UserProfile = new Profile(username);
        Save();
    }

    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(UserProfile);
            sw.Write(json);
        }
    }
    public void Load()
    {
        using (StreamReader sr = new StreamReader(savePath))
        {
            string json = sr.ReadToEnd();
            UserProfile = JsonUtility.FromJson<Profile>(json);
        }
    }

    public void DeleteProfile()
    {
        if (DoesProfileExist())
        {
            File.Delete(savePath);
        }
    }
    public bool DoesProfileExist()
    {
        if (File.Exists(savePath))
        {
            return true;
        }
        else return false;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
