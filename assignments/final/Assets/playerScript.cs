using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    float moveSpeed = 2f;
    float rotateSpeed = 50f;
    public GameObject mainCamera;
    public GameObject headlampLight;
    public AudioSource source;
    public GameObject hitObject;
    bool move;
    bool moveBack;
    public static event Action<float> UpdateNoise;
    public static event Action ClearInputPrompt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = false;
        moveBack = false;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        
        if (vAxis > 0) {
            move = true;
            UpdateNoise?.Invoke(0.1f);
            if (!source.isPlaying) {
                source.Play();
            }
        }

        animator.SetBool("move", move);
        if (vAxis < 0) {
            moveBack = true;
            UpdateNoise?.Invoke(0.1f);
            if (!source.isPlaying) {
                source.Play();
            }
        }

        if (vAxis == 0) {
            UpdateNoise?.Invoke(-0.1f);
            source.Stop();
        }

        animator.SetBool("moveBack", moveBack);

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        Vector3 moveAmount = vAxis * moveSpeed * transform.forward;

        controller.Move(moveAmount * Time.deltaTime);

        Vector3 newCameraPosition = transform.position + -transform.forward * 5 + Vector3.up * 2;
        mainCamera.transform.position = newCameraPosition;
        mainCamera.transform.LookAt(transform);
        Vector3 newLightPosition = transform.position + Vector3.up * 1.5f + transform.forward * 1;
        headlampLight.transform.position = newLightPosition;
        headlampLight.transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
        headlampLight.transform.LookAt(transform.position + Vector3.up * 1.5f + transform.forward * 1);

        Ray ray = new Ray(transform.position + new Vector3 (0, 0.5f, 0), transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1)){
            hitObject = hit.transform.gameObject;
            furnitureScript hitScript = hitObject.GetComponent<furnitureScript>();
            hitScript.checkForSearchInput();
        } else {
            ClearInputPrompt?.Invoke();
        }
    }
}
