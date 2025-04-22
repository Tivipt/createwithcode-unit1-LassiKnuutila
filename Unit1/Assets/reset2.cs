using UnityEngine;
using UnityEngine.SceneManagement;  // Import this to use SceneManager

public class reset2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload the current scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
