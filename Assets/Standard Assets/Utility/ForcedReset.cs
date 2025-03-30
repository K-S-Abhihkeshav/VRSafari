using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this for UI elements
using UnityStandardAssets.CrossPlatformInput;

public class ForcedReset : MonoBehaviour
{
    public Image resetImage; // Replaced GUITexture with UI.Image

    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
