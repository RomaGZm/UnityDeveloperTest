using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Handles popup UI: title, body text, and dynamic buttons.
/// </summary>
public class PopupView : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private GameObject buttonPrefab; // Button prefab
    [SerializeField] private Transform buttonContainer; // Layout Group parent

    /// <summary>
    /// Set popup title.
    /// </summary>
    public void SetTitle(string title) => titleText.text = title;

    /// <summary>
    /// Set popup body text.
    /// </summary>
    public void SetBody(string body) => bodyText.text = body;

    /// <summary>
    /// Setup buttons dynamically.
    /// </summary>
    public void SetupButtons(params (string text, Action callback)[] buttons)
    {
        // Clean old buttons
        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);

        int count = Mathf.Min(buttons.Length, 5);
        for (int i = 0; i < count; i++)
        {
            var btnInfo = buttons[i];
            GameObject btnObj = Instantiate(buttonPrefab, buttonContainer);
            TMP_Text btnText = btnObj.GetComponentInChildren<TMP_Text>();
            btnText.text = btnInfo.text;

            Button btnComp = btnObj.GetComponent<Button>();
            btnComp.onClick.AddListener(() =>
            {
                btnInfo.callback?.Invoke();
            });
        }
    }
}