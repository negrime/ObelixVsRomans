using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Attack(true);
        }
    }

    public void Attack(bool isRight = true)
    {
        Vector3 scale = transform.localScale;
        transform.localScale = isRight ? new Vector3(Math.Abs(scale.x), scale.y, scale.z) : new Vector3(-.9f, scale.y, scale.z);
        _animator.SetTrigger("Attack");
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<IEnemy>().OnDie();
        Destroy(other.gameObject);
        GameManager.Instance.AddScore(1);
        GameManager.Instance.AddUltimate(1);
    }
}
