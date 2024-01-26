using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentPlayer;
    public string bestPlayer;
    public int highScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int highScore;
    }

    public void SaveSession()
    {
        string saveFilePath = GetSaveFilePath();

        SaveData data = new SaveData
        {
            bestPlayer = bestPlayer,
            highScore = highScore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(saveFilePath, json);

        Debug.Log($"Successfully saved high score: {bestPlayer}: {highScore}");
    }

    public void LoadSession()
    {
        string saveFilePath = GetSaveFilePath();

        if (!File.Exists(saveFilePath))
        {
            return;
        }

        string json = File.ReadAllText(saveFilePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        bestPlayer = data.bestPlayer;
        highScore = data.highScore;

        Debug.Log($"Successfully loaded high score: {bestPlayer}: {highScore}");
    }

    string GetSaveFilePath()
    {
        string saveFilePath = $"{Application.persistentDataPath}/breakerdata.json";

        Debug.Log("Current saveFilePath: " + saveFilePath);

        return saveFilePath;
    }
}
