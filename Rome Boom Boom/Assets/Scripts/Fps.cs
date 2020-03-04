using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{
    [Header("Text for Fps count")] 
    [SerializeField]
    private Text _fpsTxt;
    private int _counter;
    private float currentTime;

    private void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                _fpsTxt.enabled = false;
                break;
            case RuntimePlatform.Android:
                _fpsTxt.enabled = true;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            _fpsTxt.enabled = !_fpsTxt.enabled;
        }

        if (!_fpsTxt.enabled) return;
        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            _fpsTxt.text = _counter.ToString();
            _counter = 0;
            currentTime = 0;
        }
        
        _counter++;
    }

}
