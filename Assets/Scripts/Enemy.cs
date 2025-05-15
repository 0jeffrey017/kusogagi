
using UnityEngine;

public class Enemy : Unit
{
    private float _speed = 10f;
    private Vector2 enemyVector;
    private float _lastChangedTime = -Mathf.Infinity;
    private float _cooldownTime = 0.3f;
    

    void Update()
    {
        if (!GameManager.Instance.isMainGameStart || GameManager.Instance.hasCatchEnemy) return;
        if ((Time.time - _lastChangedTime) >= _cooldownTime)
        {
            enemyVector = GetRandomV2();
            _lastChangedTime = Time.time;
        }

        CheckBound(this.gameObject);

        transform.Translate(_speed * Time.deltaTime * enemyVector);
    }

    private Vector2 GetRandomV2(){
        Vector2 pos = transform.position;
        Vector2 center = Vector2.zero;

        float distanceToCenter = Vector2.Distance(pos, center);
        
        float maxDistance = 9f / 2f;
        float centerBias = Mathf.Pow(distanceToCenter/maxDistance, 2);
        // Debug.Log(centerBias);

        if(centerBias > 1.5f){
            return (center - pos).normalized;
        }

        int num = Random.Range(1,5);
        return num switch
        {
            1 => Vector2.right,
            2 => Vector2.left,
            3 => Vector2.up,
            4 => Vector2.down,
            _ => Vector2.zero,
        };
    }  
}
