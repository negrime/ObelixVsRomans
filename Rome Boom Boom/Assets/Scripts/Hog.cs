using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hog : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    private int _minSec;
    [SerializeField]
    private int _maxSec;

    public GameObject[] positions;
    
    void Start()
    {
        transform.position = positions[Random.Range(0, positions.Length)].transform.position;
        _animator = GetComponent<Animator>();
        StartCoroutine(nameof(Up));
    }



    void Update()
    {
        
    }

    IEnumerator Up()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSec, _maxSec));
            _animator.SetTrigger("Up");
            yield return new WaitForSeconds(.5f);
            AudioManager.audioManager.PlaySound("pig");
        }
    }
}
