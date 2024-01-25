using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        string saveFilePath = $"{Application.persistentDataPath}/savefile.json";

        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(saveFilePath, json);
    }

    public void LoadColor()
    {
        string saveFilePath = $"{Application.persistentDataPath}/savefile.json";

        if (!File.Exists(saveFilePath))
        {
            return;
        }

        string json = File.ReadAllText(saveFilePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        TeamColor = data.TeamColor;
    }
}
