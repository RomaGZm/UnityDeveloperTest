using System.Collections.Generic;
using System.Linq;

public class EntityManager
{
    private readonly HashSet<IEntity> _entities = new();

    // Register new entity
    public void Register(IEntity entity)
    {
        if (entity == null || _entities.Contains(entity))
            return;

        _entities.Add(entity);

        // Listen to entity lifecycle events
        entity.OnDisabled += Remove;
        entity.OnDestroyed += Remove;
    }

    // Remove entity from registry
    public void Remove(IEntity entity)
    {
        if (entity == null)
            return;

        entity.OnDisabled -= Remove;
        entity.OnDestroyed -= Remove;

        _entities.Remove(entity);
    }

    public IEnumerable<IEntity> GetEntities()
    {
        return _entities;
    }

    // Return active entities only
    public IEnumerable<IEntity> GetActive()
    {
        return _entities.Where(e => e.IsActive);
    }
}