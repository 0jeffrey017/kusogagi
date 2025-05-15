using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public ParticleSystem _chargeEffect;  
    private int _counter = 0;
    [SerializeField]private TMP_Text _counterText;
    [SerializeField]private TMP_Text _scoreText;
    [SerializeField]private TMP_Text _timerText;
    [SerializeField]private GameObject _StartText;
    [SerializeField]private GameObject _Plane;
    private float _finalPlayerScore;
    private float _startTime = 0;
    private float _hitTime = 5.0f; 
    bool isFirstStart = true;

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space)&& isFirstStart)
        {
            isFirstStart = false;
            _StartText.SetActive(false);
            _Plane.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("countDown");
            StartCoroutine(TimerSet(()=> ChageScene("ScoreScene")));
        }
    }


    private void HitBySpace(){
        if (_chargeEffect.isEmitting) 
        {
            _chargeEffect.Emit(5);
        }
        _counter ++;
        _counterText.text = $"{_counter}";
    }
     private void ChageScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private IEnumerator TimerSet(System.Action action)
    {
        _startTime = 0;
        while (true)
        {
            _startTime += Time.deltaTime;
            float timeLeft = _hitTime - _startTime;
            if (timeLeft > 0f)
            {
                if (_timerText != null) _timerText.text = timeLeft.ToString("F2");
                if (Input.GetKeyDown(KeyCode.Space)) HitBySpace();
                if (GameManager.Instance != null && _scoreText != null)
                {
                    _finalPlayerScore = _counter * GameManager.Instance.Score * 100;
                    _scoreText.text = _finalPlayerScore.ToString();
                }
                yield return null;
            }
            if (timeLeft <= 0f)
            {
                Time.timeScale = 0;
                Debug.Log("countDown End!");
                GameManager.Instance.FinalScore = _finalPlayerScore;
                if (action != null) action.Invoke();
                yield break;
            }
        }
    }
}
