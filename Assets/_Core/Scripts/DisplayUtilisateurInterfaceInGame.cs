using System;
using UnityEngine;

public class DisplayUtilisateurInterfaceInGame : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private GameObject[] _lifeImg;

    private void Update()
    {
        DisplayLife();
    }

    void DisplayLife()
    {
        for (int i = 0; i < _lifeImg.Length; i++)
        {
            _lifeImg[i].SetActive(false);
        }
        _lifeImg[_playerConfig.Life / (100 / _lifeImg.Length + 1)].SetActive(true);
    }
}
