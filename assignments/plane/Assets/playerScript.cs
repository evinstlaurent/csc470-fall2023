using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    float moveSpeed = 10f;
    float rotateSpeed = 50f;
    float jumpSpeed = 10f;
    float gravityModifier = 5f;
    float yVelocity = 0;
    float fireSpeed = 3000f;
    CharacterController characterController;
    public GameObject mainCamera;
    public GameObject spellBall;
    // Start is called before the first frame update
    void Start()
    {
     characterController = gameObject.GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (!characterController.isGrounded)
        {
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        } else {
            yVelocity = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        Vector3 moveAmount = vAxis * moveSpeed * transform.forward;
        moveAmount.y = yVelocity;

        characterController.Move(moveAmount * Time.deltaTime);

        Vector3 newCameraPosition = transform.position + -transform.forward * 5 + Vector3.up * 2;
        mainCamera.transform.position = newCameraPosition;
        mainCamera.transform.LookAt(transform);

        if (Input.GetKeyDown(KeyCode.M)) {
            if (gameManager.SharedInstance.spellAmount > 0) {
                GameObject firedSpell = Instantiate(spellBall, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), gameObject.transform.rotation);
                Rigidbody rigidBody = firedSpell.GetComponent<Rigidbody>();
                rigidBody.AddForce(firedSpell.transform.forward * fireSpeed);
                gameManager.SharedInstance.UpdateSpellAmount(-1);
            }
        }
    }
}
