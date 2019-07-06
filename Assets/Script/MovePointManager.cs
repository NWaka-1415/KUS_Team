using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointManager : MonoBehaviour
{
    [SerializeField] private Transform _initialPos = null;
    [SerializeField] private Transform _endPos = null;

    [SerializeField] private CharaStatus _charaStatus = null;

    private Vector3 _moveVec = Vector3.zero;

    [SerializeField] private float _moveSpeed = 5;

    public void MoveItem(GameObject itemObj)
    {
        itemObj.transform.position = itemObj.transform.position + (_moveSpeed * _moveVec * Time.deltaTime);
        if (itemObj.transform.position.x < _endPos.position.x)
        {
            ResetItemPos(itemObj);
        }
    }

    public void ResetItemPos(GameObject itemObj)
    {
        Vector3 pos = _initialPos.position;
        pos.y = Random.Range(-4f, 4f);
        itemObj.transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        _moveVec = _endPos.position - _initialPos.position;
        _moveVec.Normalize();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_charaStatus.CharaState == CharaStatus.State.Death|| GameSceneManager.IsBonus) return;
        MoveItem(this.gameObject);
    }
}