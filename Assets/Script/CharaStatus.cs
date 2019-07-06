using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaStatus : MonoBehaviour
{
    private State _charaState = State.StandBy;

    private int _point;
    [SerializeField] private int _hp = 3;
    [SerializeField] private UIManager _uiManager = null;


    public State CharaState
    {
        set { this._charaState = value; }
        get { return this._charaState; }
    }


    public enum State
    {
        StandBy = 0,
        Jump = 1,
        Fall = 2,
        Death = 3
    }

    private void Awake()
    {
        _point = 0;
        _uiManager.SetPointText(_point);
        _uiManager.SetHpGem(hp: _hp);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            _hp--;
            float rand = Random.Range(0f, 1f);
            if (rand <= 0.31f) GameSceneManager.PlaySE(SoundManager.AudioName.Damage1);
            else if (rand <= 0.62f) GameSceneManager.PlaySE(SoundManager.AudioName.Damage2);
            else if (rand <= 0.95f) GameSceneManager.PlaySE(SoundManager.AudioName.Miss);
            else GameSceneManager.PlaySE(SoundManager.AudioName.MissNeta);
            _uiManager.SetHpGem(hp: _hp);
            if (_hp <= 0)
            {
                _hp = 0;
                _charaState = State.Death;
                _uiManager.SetGameOver();
            }
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            float rand = Random.Range(0f, 1f);
            if (rand <= 0.33f) GameSceneManager.PlaySE(SoundManager.AudioName.Item0);
            else if (rand <= 0.33f) GameSceneManager.PlaySE(SoundManager.AudioName.Item1);
            else GameSceneManager.PlaySE(SoundManager.AudioName.ItemGet);

            _hp++;
            _uiManager.SetHpGem(hp: _hp);
            if (_hp >= 3)
            {
                _hp = 3;
            }
        }
        else if (other.gameObject.CompareTag("Point"))
        {
            _point++;
            _uiManager.SetPointText(_point);
        }
        else if (other.gameObject.CompareTag("MovePoint"))
        {
            /*
             * ボーナスステージ
             */
            GameSceneManager.SetBonus();
            GameSceneManager.PlaySE(SoundManager.AudioName.Warning);
        }
    }

    public int Point => _point;
}