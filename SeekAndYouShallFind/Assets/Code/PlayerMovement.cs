using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private Transform feet;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private SceneLoader sL;
    private float groundDistance = 0.4f;
    private float gravity = -10f;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.name == "Exit")
        {
            sL.OpenMenu();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
