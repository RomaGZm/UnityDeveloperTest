using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class RegisterEntity : MonoBehaviour
{
    private void Awake()
    {
        GameWorld.Entities.Register(GetComponent<Entity>());
    }
}