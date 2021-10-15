using UnityEngine;
using Scripts.Enums;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.GetComponent<IInteractible>();
        if (temp != null)
        {
            ItemType item = temp.GetItemType();
            switch (item)
            {
                case ItemType.RedBall:
                case ItemType.BlueBall:
                case ItemType.GreenBall:
                    GameController.Instance.ChangeScore(other.gameObject.GetComponent<BallInteract>().Points, true);
                    break;
                case ItemType.HealthItem:
                    GameController.Instance.ChangeHealth(true);
                    break;
            }
        }
    }
}
