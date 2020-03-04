using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Cloud : MonoBehaviour, IMovable
{
    [SerializeField]
    private Vector3 _direction;

    public Vector3 Direction
    {
        get { return _direction;}

        set { _direction = value; }
    }
    [SerializeField]
    private float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

}
