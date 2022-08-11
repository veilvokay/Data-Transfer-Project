using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
}
