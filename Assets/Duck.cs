using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Duck : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
	[SerializeField]private Rigidbody rb; //this is to get what rigidbody physics apply to the injected object
	[SerializeField]private Transform PlayerCamera; //this is to get what rigidbody physics apply to the injected object
    public Transform playerTrans;
    private float speed = 5f;
    private float Sensitivity = 1f;
    private ScoreController scoreController;

    public GameObject GameOverUI;
    public GameObject theScore;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer() {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * speed;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Finish")
        {
            print("Finish Touched");
            theScore.SetActive(false);
            GameOverUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(other.gameObject.tag == "Egg"){
            scoreController.ScoreIncrease();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Fox")
        {
            theScore.SetActive(false);
            GameOverUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Destroy(other.gameObject);
        }

    }
}
