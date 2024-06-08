using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;
using Unity.Networking;
using UnityEngine.SceneManagement;

public class PlayerNetworkedMovement : NetworkBehaviour
{

    public Vector3 Player2Pos;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Physics")]
    public bool ExtraGravity;
    public float ExtraGravityAmount = 1800f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
        if (IsClient) { rb.transform.position = Player2Pos; }
    }

    private void Update()
    {
        // Move left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalVelocity = transform.right * horizontalInput * moveSpeed;

        // Move forward
        Vector3 forwardVelocity = transform.forward * moveSpeed;

        // Combine horizontal and forward velocities
        Vector3 velocity = horizontalVelocity + forwardVelocity;

        // Apply velocity directly to rigidbody
        rb.velocity = velocity;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (ExtraGravity == true)
        {
            rb.AddForce(Vector3.down * ExtraGravityAmount * Time.deltaTime, 0);       // adds downward force to keep the block near the ground
        }
    }

    private bool IsGrounded()
    {
        // Check if the player is grounded
        RaycastHit hit;
        float distance = 0.5f;
        return Physics.Raycast(transform.position, Vector3.down, out hit, distance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
