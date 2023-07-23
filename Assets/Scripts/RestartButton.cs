using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Button restartButton;

    private void Start()
    {
        // Get the Button component attached to the GameObject.
        restartButton = GetComponent<Button>();

        // Add a listener to the button's onClick event to call the RestartGame method.
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
