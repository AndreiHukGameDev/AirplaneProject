using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _coinsListCount;
    [SerializeField] private List<GameObject> _listCoins = new List<GameObject>();
    [SerializeField] private int _maxRadius = 100;
    private Vector3 _position;


    private void Start()
    {
        CreateCoins();
    }
    private void CreateCoins()
    {
        for (int i = 0; i < _coinsListCount; i++)
        {
            _position = Random.insideUnitCircle * _maxRadius;
            GameObject coin =  Instantiate(_coinPrefab, _position, _coinPrefab.transform.rotation, this.gameObject.transform);
            _listCoins.Add(coin);
        }
    }
    public void RemoveCoinsFromList(GameObject coin)
    {
        _listCoins.Remove(coin);
    }
    public int ReturnCoinCount()
    {
        return _listCoins.Count;
    }
    public Transform ElementTransformFromList()
    {
        return _listCoins[0].transform;
         
    }
}
