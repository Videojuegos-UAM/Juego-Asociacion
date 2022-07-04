using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEmitter : MonoBehaviour
{
    [Header("Food")]
    [SerializeField] private GameObject[] _food;
    [Header("Time")]
    [SerializeField] private float _minRandomTime;
    [SerializeField] private float _maxRandomTime;
    [Header("Position")]
    [SerializeField] private float _startingY;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    private float _random;

    private void Awake()
    {
        _random = Random.Range(_minRandomTime, _maxRandomTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (_random <= 0)
        {
            CreateFood();
        }
        _random -= Time.deltaTime;
    }

    private void CreateFood()
    {
        Instantiate(_food[Random.Range(0, _food.Length)],new Vector3(Random.Range(_minX,_maxX),_startingY,0),Quaternion.identity);
        _random = Random.Range(_minRandomTime, _maxRandomTime);
    }
}
