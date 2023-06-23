using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
//this script provides a simple game over functionality by restarting the game when the Restart() method is called
//it uses the SceneManager class to load the currently active scene, effectively resetting the game to its initial state