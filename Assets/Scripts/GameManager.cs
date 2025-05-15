
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float Score { get; set; }
    public float FinalScore { get; set; }
    public bool isNoPower;
    public bool hasCatchEnemy;
    public bool isMainGameStart = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializationAll()
    {
        isNoPower = false;
        hasCatchEnemy = false;
        isMainGameStart = false;
        FinalScore = 0;
        Score = 0;
    }

    public void SaveHighScore()
    {
        
    }
}
