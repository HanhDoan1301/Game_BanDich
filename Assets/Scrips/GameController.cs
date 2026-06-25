using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    Uimanager m_Uimanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spawnTime = 0;
        m_Uimanager = FindAnyObjectByType<Uimanager>();
        m_Uimanager.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_Uimanager.ShowGameOverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }

    public void RePlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void SpawnEnemy()
    {
        float ranXpos = Random.Range(-8f, 8f);
        Vector2 spawnPos = new Vector2 (ranXpos, 6);
        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameOver)
            return;
        m_score++;
        m_Uimanager.SetScoreText("Score: " +  m_score);
    }

    public void SetGameoverState(bool state)
    {
        m_isGameOver = state;
    }

    public bool IsGameover()
    {
        return m_isGameOver;
    }

}
