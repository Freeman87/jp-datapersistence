using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string name;
    }
    public static DataManager Instance;
    public int HighScore { get; private set; } = 0;
    public string PlayerName { get; set; } = "None";
    public string HighScoreName { get; set; } = "None";


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore(int points)
    {
        SaveData data = new SaveData();
        data.highscore = points;
        data.name = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.highscore;
            HighScoreName = data.name;
        }
    }

    public string GetHighScore()
    {
        LoadHighScore();
        return $"Highscore: {HighScoreName} : {HighScore}";
    }
}
