using UnityEngine;

public class TestSaveLoad : MonoBehaviour
{
    [System.Serializable]
    class EnemyData
    {
        public int id;
        public string name;
        public int health;
        public float speed;

        public EnemyData(int id, string name, int health, float speed)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
        }
        public override string ToString()
        {
            return $"({id} ,{name}, {health}, {speed})"; 
        }
    }
    void Start()
    {
        SaveLoadUtility.Save("EnemyData", new EnemyData(1, "Zombie", 100, 5f));
        var enemy = SaveLoadUtility.Load<EnemyData>("EnemyData");

        Debug.Log(enemy.ToString());
    }
}
