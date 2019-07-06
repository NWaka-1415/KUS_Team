using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] _hpGems = new GameObject[3];
    [SerializeField] private GameObject _gameOverPanel = null;
    [SerializeField] private Text _pointText = null;
    [SerializeField] private GameObject _warningPanel = null;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        _warningPanel.SetActive(false);
    }

    public void SetPointText(int point)
    {
        _pointText.text = $"Points: {point}";
    }

    public void SetHpGem(int hp)
    {
        for (int i = 0; i < _hpGems.Length; i++)
        {
            _hpGems[i].SetActive(i <= hp - 1);
        }
    }

    public void SetBonusPanel()
    {
        _warningPanel.SetActive(true);
    }

    public void SetGameOver()
    {
        _gameOverPanel.SetActive(true);
        float rand = Random.Range(0f, 1f);
        GameSceneManager.StopBGM();
        GameSceneManager.PlaySE(rand <= 0.4f ? SoundManager.AudioName.GameOver : SoundManager.AudioName.GameOver6);
    }
}