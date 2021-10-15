using Scripts.Enums;
using UnityEngine;
using Scripts.GameBalance;
using System.Linq;

public class BallInteract : MonoBehaviour, IInteractible
{
    [SerializeField] private ItemType _itemType;
    private int _points;            

    public int Points
    {
        get { return _points; }
    }

    private void Awake()
    {
        _points = GameBalance.Instance.ItemSettings.FirstOrDefault(t => t.ItemType == _itemType).Points;
    }

    public ItemType GetItemType()
    {
        return _itemType;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.layer != 6)
            {
                GameController.Instance.ChangeHealth(false);
            }
            //Destroy is expensive, used according to the test task
            Destroy(gameObject);
        }
    }
}
