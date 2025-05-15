using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{   
    private float _xBound = 8.5f;
    private float _yBound = 4.5f;
    public virtual void CheckBound(GameObject gameObject)
    {
        Vector3 playerPos = gameObject.transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -_xBound, _xBound);
        playerPos.y = Mathf.Clamp(playerPos.y, -_yBound, _yBound);

        gameObject.transform.position = playerPos;
    }
    
}
