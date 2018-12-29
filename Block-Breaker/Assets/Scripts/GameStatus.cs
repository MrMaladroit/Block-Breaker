using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestoryed = 3;
    [SerializeField] private int currentScore = 0;

    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestoryed;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}