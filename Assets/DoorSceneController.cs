using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneController : MonoBehaviour
{
    // Scene names should match the scenes in your Build Settings
    public string nextSceneName; // Name of the next scene to load
    public bool isLastDoor = false; // Set to true for the last door, which ends the game

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Load the next scene if it's not the last door
            if (isLastDoor)
            {
                EndGame();
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    // Load the next scene
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // End the game when the last door is found
    void EndGame()
    {
        // Display a message or trigger any end-of-game actions
        Debug.Log("Congratulations! You've completed the game.");
        
        // You can use Application.Quit() to quit the game
        // Or load a "Game Over" or "You Win" screen
        Application.Quit(); // Will work in a built game (won't work in the editor)
    }
}
