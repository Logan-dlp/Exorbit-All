using System;
using UnityEngine;

public class DisplayUtilisateurInterfaceInGame : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private GameObject _sheildImgActivate;
    [SerializeField] private GameObject _sheildImgDesactivate;
    [SerializeField] private GameObject[] _lifeImg;

    private void Update()
    {
        DisplayLife();
        DisplaySheild();
    }

    void DisplayLife()
    {
        for (int i = 0; i < _lifeImg.Length; i++)
        {
            _lifeImg[i].SetActive(false);
        }
        _lifeImg[_playerConfig.Life / (100 / _lifeImg.Length + 1)].SetActive(true);
    }

    void DisplaySheild()
    {
        if (_playerConfig.Shield > 99.99f)
        {
            _sheildImgActivate.SetActive(true);
            _sheildImgDesactivate.SetActive(false);
        }
        else
        {
            _sheildImgActivate.SetActive(false);
            _sheildImgDesactivate.SetActive(true);
        }
    }
}
