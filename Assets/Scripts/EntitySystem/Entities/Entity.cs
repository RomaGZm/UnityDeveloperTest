using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour, IEntity
{

    public bool IsActive => _isActive;
    private bool _isActive = true;

    public Entity(bool isActive)
    {
        _isActive = isActive;
    }

    public event Action<IEntity> OnDisabled;
    public event Action<IEntity> OnDestroyed;

    // Mark entity as inactive (gameplay logic)
    public void Disable()
    {
        if (_isActive == false) return;

        _isActive = false;
        OnDisabled?.Invoke(this);
    }
    public void Destroy()
    {
        OnDestroy();
    }
    
    //Destroy hook
    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

}