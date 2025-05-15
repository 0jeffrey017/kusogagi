using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    void Update()
    {
        if (GameManager.Instance != null)
        {   float score = GameManager.Instance.FinalScore;
            _scoreText.text = $"Score : {score}";
        }
    }

    public void BackToMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
