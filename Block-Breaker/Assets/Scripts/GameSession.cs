using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestoryed = 3;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private bool isAutoPlayEnabled;

    private GameSession instance; 

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestoryed;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void ResetGameSessionGameObject()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
    
}