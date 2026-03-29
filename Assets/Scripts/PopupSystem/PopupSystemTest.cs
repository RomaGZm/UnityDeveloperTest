using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSystemTest : MonoBehaviour
{
    public PopupManager popupManager;

    private void Start()
    {
       // ShowPopup();
    }

    public void ShowPopup()
    {
        PopupView view = null;
        view = popupManager.ShowPopup("Title!!", "You Win!!",

            ("Next", () => 
            {
                SceneManager.LoadScene(1);
            }
            ),
            ("Restart", () =>
            {
                SceneManager.LoadScene(0);
            }
            ),
            ("Exit", () =>
            {
                Application.Quit();
            })
            );
    }
}
