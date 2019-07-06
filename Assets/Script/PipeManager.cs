using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private CharaStatus _charaStatus = null;
    [SerializeField] private GameObject[] _pipeList;

    [SerializeField] private float _moveSpeed = 5;

    private Vector3 _moveVec = Vector3.zero;

    [SerializeField] Transform _initialPos;
    [SerializeField] Transform _endPos;

    public float Speed
    {
        set { this._moveSpeed = value; }
        get { return this._moveSpeed; }
    }

    public void Move_Pipe(GameObject pipeObj)
    {
        pipeObj.transform.position = pipeObj.transform.position + (_moveSpeed * _moveVec * Time.deltaTime);
        if (pipeObj.transform.position.x < _endPos.position.x)
        {
            Reset_Pipe_Pos(pipeObj);
        }
    }

    private void Set_Move_Range()
    {
        Vector3 startPos = _pipeList[0].transform.position;
        startPos.y = 0;
        _initialPos.position = startPos;

        Vector3 pipesSpace = _pipeList[0].transform.position - _pipeList[_pipeList.Length - 1].transform.position;
        pipesSpace.y = 0;
        pipesSpace /= _pipeList.Length - 1;
        _endPos.position = _initialPos.position + (pipesSpace * _pipeList.Length);
    }

    public void Reset_Pipe_Pos(GameObject pipeObj)
    {
        Vector3 pos = _initialPos.position;
        pos.y = pipeObj.transform.position.y;
        pipeObj.transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        _moveVec = _endPos.position - _initialPos.position;
        _moveVec.Normalize();
        Set_Move_Range();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSceneManager.IsBonus) return;
        if (_charaStatus.CharaState == CharaStatus.State.Death) return;
        for (int i = 0; i < _pipeList.Length; i++)
        {
            Move_Pipe(_pipeList[i]);
        }
    }
}