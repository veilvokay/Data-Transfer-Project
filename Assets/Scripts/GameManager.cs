using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    public static GameManager GetGameManager()
    {
        return Instance;
    }

    private int m_PointsCurrent = 0;
    private int m_PointsBestScore = 0;
    private string m_PlyaerName;

    public int CurrentPoints
    {
        get => m_PointsCurrent;
        set => m_PointsCurrent = value;
    }

    public int CurrentBestScore
    {
        get => m_PointsBestScore;
        set => m_PointsBestScore = value;
    }

    public string PlayerName
    {
        get => m_PlyaerName;
        set => m_PlyaerName = value;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSessionData();
    }

    public int AddPoint(int point)
    {
        m_PointsCurrent += point;
        return m_PointsCurrent;
    }

    public int UpdateBestScore()
    {
        if (m_PointsCurrent > m_PointsBestScore)
        {
            m_PointsBestScore = m_PointsCurrent;
        }
        return m_PointsBestScore;
    }

    public void UpdateBestScoreText(TextMeshProUGUI textObject)
    {
        int bestScore = UpdateBestScore();
        textObject.text = $"Best Score : {PlayerName} : {bestScore}";
    }

    public void UpdateBestScoreText(Text textObject)
    {
        int bestScore = UpdateBestScore();
        textObject.text = $"Best Score : {PlayerName} : {bestScore}";
    }


    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int PlayerBestScore;
    }

    public void SaveSesionData()
    {
        SaveData data = new SaveData
        {
            PlayerName = PlayerName,
            PlayerBestScore = CurrentBestScore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/game-save-file.json", json);
    }

    public void LoadSessionData()
    {
        string path = Application.persistentDataPath + "/game-save-file.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            CurrentBestScore = data.PlayerBestScore;
        }
    }
}
