using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class Gladiator : MonoBehaviour, IMovable, IEnemy
{
    public Vector3 Direction { get; set; }
    

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _stopDistance; 
    private bool isAttacked;

    public float Speed
    {
        get {return _speed;}
        set {_speed = value;}
    }
    private Rigidbody2D _rb;
    private Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        isAttacked = false;
    }
    
    private void FixedUpdate() 
    {
        if (Vector2.Distance(transform.position, GameManager.Instance.Player.transform.position) > _stopDistance)
        {
            Move();
        }
        else
        {
            if (!isAttacked)
            {
                _animator.SetTrigger("Attack");
                isAttacked = true;
            }
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                Move();
            }
        }
    }

    public void OnDie()
    {

    }

    public void Move()
    {
        _rb.MovePosition(transform.position + _speed * Time.deltaTime * Direction);
    }
}
