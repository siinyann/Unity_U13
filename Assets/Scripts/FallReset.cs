using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    [Tooltip("The Y-axis coordinate at which the player is considered fallen.")]
    public float fallThreshold = -100f;

    void Update()
    {
        // Check if the character's Y position goes below the threshold
        if (transform.position.y < fallThreshold)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reloads the currently active scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}