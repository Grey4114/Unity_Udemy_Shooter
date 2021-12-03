using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start() 
    {
        gameOverCanvas.enabled = false;         // Hides the game over canvas during game play   
    }

    
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;              // Shows the game over canvas
        Time.timeScale = 0;                         // Stops game play
        FindObjectOfType<WeaponSwitcher>().enabled = false; // Disables the keyboard and mouse wheel weapon switching
        Cursor.lockState = CursorLockMode.None;     // Unlocks the cursor
        Cursor.visible = true;                      // Shows the cursor
    }
}
