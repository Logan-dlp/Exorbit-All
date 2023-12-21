using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private Text _text;

    private void Start()
    {
        _text.text = _statsManager.score.ToString();
    }
}
