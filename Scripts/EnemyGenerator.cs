using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private int _rocketPrefabCount;

    [SerializeField] private GameObject _bombaPrefab;
    [SerializeField] private int _bombaPrefabCount;
    [SerializeField] private List<GameObject> _listOfBobs = new List<GameObject>();
    [SerializeField] private List<GameObject> _listOfRocket = new List<GameObject>();

    [SerializeField] private int _maxRadius = 80;
    private Vector3 _spawnPoint;

    private void Start()
    {
        CreateEnemy(_bombaPrefab, _bombaPrefabCount, _listOfBobs);
        CreateEnemy(_rocketPrefab, _rocketPrefabCount, _listOfRocket);
    }
    private void CreateEnemy(GameObject prefab, int countEnemy, List<GameObject> list)
    {
        for (int i = 0; i < countEnemy; i++)
        {
            _spawnPoint = Random.insideUnitCircle * _maxRadius;
            GameObject ob =  Instantiate(prefab, _spawnPoint, prefab.transform.rotation, gameObject.transform);
            list.Add(ob);
        }
    }
    public void RemoveBombsFromList(GameObject bomb)
    {
        _listOfBobs.Remove(bomb);
    }
    public void RemoveRocketFromList(GameObject rocket)
    {
        _listOfRocket.Remove(rocket);
    }
    public int ReturnBombCount()
    {
        return _listOfBobs.Count; 
    }
    public int ReturnRocketCount()
    {
        return _listOfRocket.Count;
    }
}
