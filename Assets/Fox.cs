using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
		Debug.Log("Fox Touched");
		if(other.gameObject.tag == "Ammo"){
			Destroy(gameObject);
		}
	}
}
//This script provides collision detection functionality for a game object representing a fox
//If the fox collides with another game object that has the "Ammo" tag, the fox game object itself is destroyed