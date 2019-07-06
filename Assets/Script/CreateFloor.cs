using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    [SerializeField] private Transform _initialCreatePos;
    [SerializeField] private Transform _initialCreatePosTop;
    [SerializeField] private GameObject _floorObjSource;
    [SerializeField] private float _floorSetDistance = 0.8f;

    private GameObject Create(Vector3 createPos, Transform initialCreatePos)
    {
        GameObject floor = Instantiate(_floorObjSource, createPos, Quaternion.identity);
        floor.transform.parent = initialCreatePos.transform;
        return floor;
    }

    void Awake()
    {
        Vector2 createPos = _initialCreatePos.position;
        Vector2 createPosTop = _initialCreatePosTop.position;

        for (int i = 0; i < 24; i++)
        {
            Create(createPos, _initialCreatePos);
            Create(createPosTop, _initialCreatePosTop);
            createPos.x += _floorSetDistance;
            createPosTop.x += _floorSetDistance;
        }
    }
}