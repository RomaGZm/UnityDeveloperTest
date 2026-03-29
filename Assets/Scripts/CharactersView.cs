using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersView : MonoBehaviour
{
    class Character
    {
        public float Value;
    }

    [SerializeField] private List<Character> _characters;
    private Text _text;
    private float timeCounter = 0;
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= 0.1f)
        {
            timeCounter = 0;
            int count = _characters.Count;
            if (count == 0)
            {
                _text.text = "Символы: 0 Среднее значение: 0";
                return;
            }
            float totalValue = 0f;

            foreach (Character _character in _characters)
            {
                if (_character != null)
                    totalValue += _character.Value;
            }

            float average = totalValue / count;

            string text = $"Символы: {count} Среднее значение: {average:F2}";
            _text.text = text;
        }
    }
}

