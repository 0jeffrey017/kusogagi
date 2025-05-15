using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public Button _buttonForCountine;
    public Button _buttonForLose;
    public TMP_Text _loseMessage;
    public Image _fadeStart;
    public Image _fadeEnd;
    public TMP_Text _StartMessage;

    [SerializeField]private float _fadeTime = 2.0f;
    private float _StartlastTime;
    private float _EndlastTime;
    void Awake()
    {
        _fadeStart.color = new Color(0, 0, 0, 1);
        _fadeStart.raycastTarget = true;
        _StartMessage.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log($"Key down");
            StartCoroutine(FadeInMapScene());
        }

        if (GameManager.Instance.hasCatchEnemy)
        {
            _buttonForCountine.gameObject.SetActive(true);
            StartCoroutine(FadeOutToHitScene());
        }
        if (GameManager.Instance.isNoPower)
        {   
            _buttonForLose.gameObject.SetActive(true);
            _loseMessage.gameObject.SetActive(true);
            StartCoroutine(FadeOutToHitScene());
        }
    }

    private IEnumerator FadeInMapScene(){
        _fadeStart.color = new Color(0,0,0,1);
        while (true)
        {
            _StartlastTime += Time.deltaTime;
            Color newColor = _fadeStart.color;
            float fadePer = _StartlastTime / _fadeTime;
            float a = 1 - fadePer;
            if (_StartlastTime < _fadeTime)
            {
                newColor.a = a;
                _fadeStart.color = newColor;
                Debug.Log(_StartlastTime);
                yield return null;
            }
            else
            {
                newColor.a = 0;
                _fadeStart.color = newColor;
                _fadeStart.raycastTarget = false;
                GameManager.Instance.isMainGameStart = true;
                _StartMessage.gameObject.SetActive(false);
                yield break;
            }
        }
    }
    private IEnumerator FadeOutToHitScene(){
        _fadeEnd.raycastTarget = true;
        _fadeStart.color = new Color(1,0,0,0);
        while (true)
        {
            _EndlastTime += Time.deltaTime;
            Color newColor = _fadeStart.color;
            float fadePer = Mathf.Clamp(_EndlastTime / _fadeTime,0.0f,0.7f);
            float a = fadePer;
            if (_EndlastTime < _fadeTime)
            {
                newColor.a = a;
                _fadeStart.color = newColor;
                yield return null;
            }
            else
            {
                newColor.a = 0.7f;
                _fadeStart.color = newColor;
                yield break;
            }
        }
    }
    

}
