using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class RotationHandler
{
    public KeyCode input;
    public Vector3 direction;
    public Transform transform;

    private bool hasTapped;

    
    public void Update()
    {
        if (Input.GetKeyDown(input))
        {
            hasTapped = true;
        }
    }

    public void FixedUpdate()
    {
        Debug.Log($"Input {input} pressed: {Input.GetKey(input)}");
        if (Input.GetKey(input) || hasTapped)
        {
            transform.Rotate(direction);
        }

        hasTapped = false;
    }
}
public class Head : MonoBehaviour
{
    public RotationHandler[] rotationHandlers;
    [SerializeField] private GameField _gameField;
    [SerializeField] private Body _bodyPrefab;
    
    void Start()
    {
        Vector3 position = Vector3.zero;
        position.x = _gameField.width / 2 - _gameField.HalfWidth + .5f;
        position.y = _gameField.height / 2 - _gameField.HalfHeight + .5f;
    }

    


    public void Update()
    {
        for (int i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].Update();
        }
        
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].FixedUpdate();
        }

        Vector3 nextPosition = transform.position + transform.up;
        nextPosition.x = (nextPosition.x + 3*_gameField.HalfWidth) % _gameField.width - _gameField.HalfWidth;
        nextPosition.y = (nextPosition.y + 3*_gameField.HalfHeight) % _gameField.height - _gameField.HalfHeight;

        RaycastHit2D hit = Physics2D.BoxCast((Vector2)nextPosition, Vector2.one*.9f, 0f, Vector2.zero);
        Pikachuu pikachuu = hit.collider?.GetComponent<Pikachuu>();
        if (pikachuu == null)
        {
            //no pikachuu eaten, move da lazy bod
        }
        else
        {
            //pikachuu in belly, get growin
            Body newBody = Instantiate(_bodyPrefab, transform.position, transform.rotation);
            pikachuu.OnEaten();
        }
        transform.position = nextPosition;


    }
}
