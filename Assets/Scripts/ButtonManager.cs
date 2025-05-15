
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void LoadSceneHit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HitScene");
    }
    public void LoadSceneMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene"); 
    }
}
