using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public static GameManager instance
    {
        get
        {
            if(Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }
    }

    private int score = 0;
    public bool inGameOver { get; private set; }
    

    private void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindObjectOfType<PlayerHealth>().OnDeath += EndGame;
    }

    public void EndGame()
    {
        inGameOver = true;
        UIManager._Inst.SetGameOver(true);
    }

    public void AddScore(int newScore)
    {
        if (!inGameOver)
        {
            score += newScore;

            UIManager._Inst.UpdateScoreText(score);
        }
    }
}
