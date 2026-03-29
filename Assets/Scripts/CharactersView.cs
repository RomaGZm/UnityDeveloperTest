using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersView : MonoBehaviour
{
    [SerializeField] private List<Transform> _characters;

    private Text _text; 

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        int count = _characters.Count;
        if (count == 0)
        {
            _text.text = "Символы: 0 Среднее значение: 0";
            return;
        }
        float totalValue = 0f;

        foreach (Transform characterTransform in _characters)
        {
            Character character = characterTransform.GetComponent<Character>();

            if (character != null)
                totalValue += character.Value;
        }

        float average = totalValue / count;

        string text = $"Символы: {count} Среднее значение: {average:F2}";
        _text.text = text;

       // Debug.Log(text);
    }
}
class Character
{
    public float Value;
}

