
using UnityEngine;


public class PlayerController : Unit
{
    private float _PHorizontal;
    private float _PVertical;
    private float _speed = 5.0f;

    void Update()
    {   
        if (!GameManager.Instance.isMainGameStart || GameManager.Instance.hasCatchEnemy) return;
        CheckBound(this.gameObject);
        _PHorizontal = Input.GetAxis("Horizontal");
        _PVertical = Input.GetAxis("Vertical");

        transform.Translate(_PHorizontal * _speed * Time.deltaTime * Vector3.right);
        transform.Translate(_PVertical * _speed * Time.deltaTime * Vector3.up);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            GameManager.Instance.hasCatchEnemy = true;
            Debug.Log("enemy has Catched");
        }
    }

}
