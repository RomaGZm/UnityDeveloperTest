using System;
using UnityEngine;

/// <summary>
/// Handles popup creation and button setup.
/// </summary>
public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab; // assign prefab in inspector
    [SerializeField] private Transform popupParent;  // Canvas or empty parent for popups

    /// <summary>
    /// Show a popup with dynamic buttons.
    /// </summary>
    public PopupView ShowPopup(string title, string body, params (string text, Action callback)[] buttons)
    {
        GameObject popupObj = Instantiate(popupPrefab, popupParent);
        PopupView view = popupObj.GetComponent<PopupView>();

        if (view != null)
        {
            view.SetTitle(title);
            view.SetBody(body);
            view.SetupButtons(buttons);
            return view;
        }
        else
        {
            Debug.LogError("[PopupManager] Popup prefab missing PopupView component!");
        }
        return null;
    }
}