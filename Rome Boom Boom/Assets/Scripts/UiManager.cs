using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoresTxt;
    [SerializeField]
    private Animator _scoresAnimator;

    [SerializeField]
    private Slider _sliderUltimate;

    public void UpdateScores(int value)
    {
        _scoresAnimator.SetTrigger("AddValue");
        _scoresTxt.text = value.ToString();
    }

    public void UpdateUltimate(int value)
    {
        _sliderUltimate.value = value;
    }
}
