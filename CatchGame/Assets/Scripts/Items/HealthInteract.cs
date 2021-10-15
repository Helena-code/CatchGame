using Scripts.Enums;
using UnityEngine;

public class HealthInteract : MonoBehaviour, IInteractible
{
    [SerializeField] private ItemType _itemType;

    public ItemType GetItemType()
    {
        return _itemType;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            //Destroy is expensive, used according to the test task
            Destroy(gameObject);
        }
    }
}
