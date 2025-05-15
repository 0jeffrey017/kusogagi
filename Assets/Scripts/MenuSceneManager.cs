using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{   
    [SerializeField]private Image _fade;
    [SerializeField]private float _fadeTime;
    private float _lastTime;
    private enum ESceneName{
        MapScene,HitScene,MenuScene
    }  


    
    public void ClickButtonChageToMainScene(){

        StartCoroutine(FazaOutInMenuScene(
            () => ChageScene(ESceneName.MapScene.ToString())
        ));
    }

    private void ChageScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FazaOutInMenuScene(System.Action action){
            _fade.raycastTarget = true;
        while(true){
            _lastTime += Time.deltaTime;
            Color newColor = _fade.color;
            float fadePer = _lastTime / _fadeTime;
            float a = fadePer;
            if(_lastTime < _fadeTime){
                newColor.a = a;
                _fade.color = newColor;
                yield return null;
            }else{
                newColor.a = 1;
                _fade.color = newColor;
                if(action != null) action.Invoke();
                yield break;
            }
        }
    }
}
