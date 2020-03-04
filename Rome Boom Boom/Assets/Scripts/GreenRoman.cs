using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenRoman : MonoBehaviour, IMovable, IEnemy
{
    [SerializeField]
    private float _speed;

    [Header("Die objects")] 
    [SerializeField]
    private GameObject _spear;

    [SerializeField] 
    public GameObject _shield;
    
    
    private Rigidbody2D _rb;

    public Vector3 Direction { get; set; }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = (float)Math.Round(Random.Range(1.5f, 2.5f), 2);
    }    
    
    private void FixedUpdate()
    {
        Move();
    }

    public void OnDie()
    { 
        GameObject spear = Instantiate(_spear, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        spear.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(300, 500));
        Destroy(spear, 3);
        
        GameObject shield = Instantiate(_shield, transform.position, Quaternion.Euler(0,0, Random.Range(0, 360)));
        shield.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(200, 400));
        Destroy(shield, 3);
    }

    public void Move()
    {
        Vector3 target = GameManager.Instance.StartPosition.transform.position;
        if (Vector2.Distance(transform.position, target) > 1)
        {
            _rb.MovePosition(transform.position + _speed * Time.deltaTime * Direction);
        }
    }
}
