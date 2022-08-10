using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private GameManager Manager;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text BestScoreText;
    public Text ScoreText;
    public GameObject GameOverContainer;
    
    private bool m_Started = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GetGameManager() != null)
        {
            Manager = GameManager.GetGameManager();
            Manager.CurrentPoints = 0;
            UpdateBestScore();
        }

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                //brick.onDestroyed.AddListener(AddPoint);
                brick.onDestroyed.AddListener(UpdateScore);

            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
    }

    //void AddPoint(int point)
    //{
    //    m_Points += point;
    //    ScoreText.text = $"Score : {m_Points}";
    //}

    void UpdateScore(int point)
    {
        int currPoints = Manager.AddPoint(point);
        ScoreText.text = $"Score : {currPoints}";
    }

    void UpdateBestScore()
    {
        int bestScore = GameManager.GetGameManager().UpdateBestScore();
        BestScoreText.text = $"Best Score : : {bestScore}";
    }

    public void GameOver()
    {
        UpdateBestScore();
        GameOverContainer.SetActive(true);
    }
}
