
using UnityEngine;
using UnityEngine.UI;

public class SliderDecay : MonoBehaviour
{
    public Scrollbar scrollbar;         
    private float decaySpeed = 1f;
    [SerializeField]private PlayerController player;
    public float playerScore { get; private set; }

    

    
    void Awake()
    {   
        if (scrollbar != null){
            scrollbar.size = 1;
        }
    }
    void Update()
    {   

        if (GameManager.Instance.hasCatchEnemy){
            playerScore = scrollbar.size;
            GameManager.Instance.Score = playerScore;
            return;
        }
        if (scrollbar != null && scrollbar.size > 0 && !GameManager.Instance.hasCatchEnemy)
        {
            scrollbar.size -= decaySpeed * Time.deltaTime * 0.1f;
        }
        if (scrollbar.size == 0){
            scrollbar.gameObject.SetActive(false);
            GameManager.Instance.isNoPower = true;
        }
    }    
}
