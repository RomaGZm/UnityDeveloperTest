using System;

public interface IEntity
{
    bool IsActive { get; }
    event Action<IEntity> OnDisabled; 
    event Action<IEntity> OnDestroyed; 
}