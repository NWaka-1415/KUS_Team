using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private float _offsetX = 19f;
    [SerializeField] private GameObject[] _bgObj = null;
    [SerializeField] private Transform _initialPos = null;
    [SerializeField] private CharaStatus _charaStatus = null;


    private Vector2[] _bgDefaultPos;

    // Start is called before the first frame update
    void Start()
    {
        _bgDefaultPos = new Vector2[_bgObj.Length];
        for (int i = 0; i < _bgObj.Length; i++)
        {
            _bgDefaultPos[i] = _bgObj[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_charaStatus.CharaState == CharaStatus.State.Death) return;

        for (int i = 0; i < _bgObj.Length; i++)
        {
            if (_bgObj[i].transform.position.x <= _initialPos.position.x)
            {
                int index = i - 1 >= 0 ? i - 1 : _bgObj.Length - 1;
                _bgObj[i].transform.position =
                    _bgDefaultPos[index] +
                    new Vector2(_offsetX, 0f);
            }

            _bgObj[i].transform.Translate(-0.05f, 0f, 0f);
            _bgDefaultPos[i] = _bgObj[i].transform.position;
        }
    }
}