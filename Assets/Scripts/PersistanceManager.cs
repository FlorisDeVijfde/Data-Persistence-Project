using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for saving and loading file
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance;
    public string playerName;
    public int topScore;
    public string topScorerName;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int savedTopScore;
        public string savedTopScorerName;
    }

    public void SaveTopScore(int tScore)
    {
        SaveData saveData = new SaveData();
        saveData.savedTopScore = tScore;

        saveData.savedTopScorerName = PersistanceManager.Instance.playerName;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
    }

    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            topScore = saveData.savedTopScore;
            topScorerName = saveData.savedTopScorerName;

        }
        else
        {
            topScore = 0;
            topScorerName = "Nobody";
        }
    }
}
