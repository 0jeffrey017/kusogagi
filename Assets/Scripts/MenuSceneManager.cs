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

    private IEnumerator FadeOutInMenuScene(System.Action action){
            _fade.raycastTarget = true;
            _lastTime = 0f;
        while (true)
        {
            _lastTime += Time.deltaTime;
            Color newColor = _fade.color;
            float fadePer = _lastTime / _fadeTime;
            float a = fadePer;
            if (_lastTime < _fadeTime)
            {
                newColor.a = a;
                _fade.color = newColor;
                yield return null;
            }
            else
            {
                newColor.a = 1;
                _fade.color = newColor;
                if (action != null) action.Invoke();
                _fade.raycastTarget = false;
                Debug.Log("IEnumerator FazaOutInMenuScene over");
                yield break;
            }
        }
    }
}
