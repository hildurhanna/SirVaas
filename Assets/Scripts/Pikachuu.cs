using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Pikachuu : MonoBehaviour
{
    private void Start()
    {
        Respawn();
    }

    [SerializeField] private GameField _gamefield;
    public void OnEaten()
    {
        Respawn();
    }

    void Respawn()
    {
        Vector3 newPosition = Vector3.zero;
        // 0,1,2,3,4,5,6,7,8
        //-4.5,-3.5-2.5-1.5--0.5 0.5 1.5 2.5 3.5
        newPosition.x = Random.Range(0,_gamefield.width)- _gamefield.HalfWidth+.5f;
        newPosition.y = Random.Range(0,_gamefield.height)- _gamefield.HalfHeight+.5f;
        newPosition.z = -1; 
        transform.position = newPosition;
    }
}
