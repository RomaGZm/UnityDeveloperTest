using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("Prefab & Grid Settings")]
    [SerializeField] private GameObject prefab; 
    [SerializeField] private int rows = 5;      
    [SerializeField] private int columns = 5;   
    [SerializeField] private float spacing = 2f; 

    [ContextMenu("Spawn Grid")]
    public void SpawnGrid()
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab is not assigned!");
            return;
        }
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);

                var entity = Instantiate(prefab, position, Quaternion.identity, transform).GetComponent<Entity>();
                GameWorld.Entities.Register(entity);
            }
        }
    }

    // Optional: Automatically spawn on start
    private void Start()
    {
        SpawnGrid();
    }
}