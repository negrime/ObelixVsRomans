using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Stats")] 
    [SerializeField]
    private int _scores;

    
    [SerializeField]
    private bool _isAlive;
    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    [SerializeField]
    private int _ultimate;
    
    
    
    public static GameManager Instance;
    
    private Player _player;
    public Player Player
    {
        get => _player;
        set => _player = value;
    }

    [SerializeField]
    private Transform _startPosition;

    public Transform StartPosition => _startPosition;


    [Header("UI")] 
    private UiManager _uiManager;


    private void Awake()
    {
        #region Singleton
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    private void Start()
    {
        _uiManager = GetComponent<UiManager>();
        _player = FindObjectOfType<Player>();
    }

    public void AddScore(int value)
    {
        _scores += value;
        _uiManager.UpdateScores(_scores);
    }

    public void AddUltimate(int value)
    {
        _ultimate += value;
        _uiManager.UpdateUltimate(_ultimate);
    }

  


}
