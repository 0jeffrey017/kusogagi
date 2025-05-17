using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{   
    [SerializeField]private Image _fade;
    [SerializeField]private float _fadeTime;
    public Button _startButton;
    private float _lastTime;
    private enum ESceneName{
        MapScene,HitScene,MenuScene
    }

    void Start()
    {
        _fade.raycastTarget = false;
        GameManager.Instance.InitializationAll();
        Color color = _fade.color;
        color.a = 0f;
        _fade.color = color;
        _startButton.onClick.AddListener(ClickButtonChangeToMainScene);
    }

    public void ClickButtonChangeToMainScene(){
        Debug.Log("button had click");
        StartCoroutine(FadeOutInMenuScene(
            () => ChangeScene(ESceneName.MapScene.ToString())
        ));
    }

    private void ChangeScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOutInMenuScene(System.Action action)
    {
        _fade.raycastTarget = true;
        _lastTime = 0f;
        Debug.Log("FadeOutInMenuScene Start");
        while (_lastTime < _fadeTime)
        {
            _lastTime += Time.deltaTime;
            Debug.Log($"FadeOutInMenuScene _lastTime = {_lastTime}");
            Color newColor = _fade.color;
            float fadePer = _lastTime / _fadeTime;
            float a = fadePer;
            newColor.a = a;
            _fade.color = newColor;
            yield return null;
        }
        Color Color = _fade.color;
        Color.a = 1;
        _fade.color = Color;
        _fade.raycastTarget = false;
        Debug.Log("IEnumerator FazaOutInMenuScene over");
        if (action != null) action.Invoke();
        yield break;

    }
}
