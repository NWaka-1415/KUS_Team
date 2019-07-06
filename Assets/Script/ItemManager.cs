using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private CharaStatus _charaStatus = null;
    [SerializeField] private GameObject[] _items = null;
    [SerializeField] private float _moveSpeed = 5;

    private Vector3 _moveVec = Vector3.zero;

    [SerializeField] private Transform _initialPos = null;
    [SerializeField] private Transform _endPos = null;


    public void MoveItem(GameObject itemObj)
    {
        itemObj.transform.position = itemObj.transform.position + (_moveSpeed * _moveVec * Time.deltaTime);
        if (itemObj.transform.position.x < _endPos.position.x)
        {
            ResetItemPos(itemObj);
        }
    }

    private void SetMoveRange()
    {
        Vector3 startPos = _items[0].transform.position;
        startPos.y = 0;
        _initialPos.position = startPos;

        Vector3 pipesSpace = _items[0].transform.position - _items[_items.Length - 1].transform.position;
        pipesSpace.y = 0;
        pipesSpace /= _items.Length - 1;
        _endPos.position = _initialPos.position + (pipesSpace * _items.Length);
    }

    public void ResetItemPos(GameObject itemObj)
    {
        Vector3 pos = _initialPos.position;
        pos.y = Random.Range(-4f, 4f);
        itemObj.transform.position = pos;
        itemObj.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _moveVec = _endPos.position - _initialPos.position;
        _moveVec.Normalize();
        SetMoveRange();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSceneManager.IsBonus) return;
        if (_charaStatus.CharaState == CharaStatus.State.Death) return;
        for (int i = 0; i < _items.Length; i++)
        {
            MoveItem(_items[i]);
        }
    }
}