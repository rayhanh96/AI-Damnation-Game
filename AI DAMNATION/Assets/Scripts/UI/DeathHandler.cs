using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;

        Time.timeScale = 0;

        // To get mouse out of game mode, equivelant of escape
        Cursor.lockState = CursorLockMode.None;

        // Make cursor visible
        Cursor.visible = true;
    }
}
