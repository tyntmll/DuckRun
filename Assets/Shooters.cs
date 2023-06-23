using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    //init variables
	[SerializeField]private GameObject SpawnPoint; //basically this is where the ammo is going to be shot from
	[SerializeField]private GameObject Ammo; //the ammo
	[SerializeField]private GameObject Ammo_Hole; //basically where the amo came from
	[SerializeField]private Transform PlayerCamera; //store the main PlayerCamera here
	GameObject temp; //instantiate the ammo
    void Update()
    {
		//let's spam le ammo
		if(Input.GetMouseButtonDown(0)) { //What do if we press the left mouse button?
			temp = Instantiate(Ammo, Ammo_Hole.transform.position, Ammo_Hole.transform.rotation) as GameObject; //this is to fire a shot or two from the SpawnPoint
			temp.transform.Rotate(Vector3.left * 90);
			Destroy (temp, 5); //you need to destroy the summoned object as not to let your computer sizzle
		}
		if(temp) {
			temp.GetComponent<Rigidbody>().AddForce(PlayerCamera.forward * 90); //push the ammo forward
		}
    }

	private void OnCollisionEnter(Collision other) {
		Debug.Log("Fox Touched");
		if(other.gameObject.tag == "Fox"){
			Destroy(other.gameObject);
		}
	}
}
// Overall, this script allows the player to shoot ammo from a specified spawn point in the direction of the player's camera 
// When the ammo collides with an object tagged as "Fox," it destroys the fox object and logs a debug message




