using System.Collections.Generic;
using UnityEngine;
using Scripts.Enums;
using Scripts.GameBalance;

public class SpawnerLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemsPrefabs;
    [SerializeField] private Transform _transform;

    private Dictionary<ItemType, GameObject> _itemsDictionary;
    private List<ItemParams> _itemParams; 

    private void Awake()
    {
        _itemsDictionary = new Dictionary<ItemType, GameObject>();

        foreach (var item in _itemsPrefabs)
        {
            var temp = item.GetComponent<IInteractible>();
            _itemsDictionary.Add(temp.GetItemType(), item);
        }
        _itemParams = GameBalance.Instance.ItemSettings;
    }

    private void FixedUpdate()
    {
        foreach (var item in _itemParams)
        {
            float rand = Random.Range(0f, 1f);
            // 60 sec per min, 50 calls per sec
            float _chance = ((float)item.Chance / 60 / 50);     
            if (rand < _chance)              
            {
                // Instantiate used according to the test task
                // Instantiate is expensive, best practice is to create a pool of objects
                var obj = Instantiate(_itemsDictionary[item.ItemType]);
                obj.transform.position = CalculateItemPosition();
            }
        }
    }

    private Vector2 CalculateItemPosition()
    {
        float rand = Random.Range(-1f, 1f);
        return new Vector2(_transform.localScale.x * rand, transform.position.y);
    }

    public void ClearFallingItems()
    {
        var balls = FindObjectsOfType<BallInteract>();
        foreach (var item in balls)
        {
            //Destroy is expensive, used according to the test task
            Destroy(item.gameObject);
        }
        var health = FindObjectsOfType<HealthInteract>();
        foreach (var item in health)
        {
            //Destroy is expensive, used according to the test task
            Destroy(item.gameObject);
        }
    }
}
