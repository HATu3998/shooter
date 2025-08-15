using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    private int score = 0;
    private bool isGameOver = false;
    public GameObject GameOverScreen;
    public GameObject ScoreObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            PlayerDie();
        }
    }
    public void addScore(int scoreValue)
    {
        score += scoreValue;
    }
    public int getScore()
    {
        return score;
    }
    public void EnemySkillPlayer()
    {
        isGameOver = true;
    }
    public void PlayerDie()
    {
        GameOverScreen.SetActive(true);
        ScoreObject.SetActive(false);
    }
    public bool GameOver()
    {
        return isGameOver;
    }
}
