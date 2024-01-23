using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// TODO: import UnityEngine.InputSystem and UnityEngine.SceneManagement


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    Vector3 moveValue = Vector2.zero;
    bool pancaked = false;
    // TODO: add component references


    // TODO: add variables for speed, jumpHeight, and respawnHeight

    // TODO: add variable to check if we're on the ground


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // TODO: Get references to the components attached to the current GameObject

    }

    // Update is called once per frame
    void Update()
    {
        Move(moveValue.x, moveValue.y);
        // TODO: check if player is under respawnHeight and call Respawn()

    }

    void OnJump()
    {
        Jump();
        // TODO: check if player is on the ground, and call Jump()

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        // TODO: Set the y velocity to some positive value while keeping the x and z whatever they were originally

    }

    void OnMove(InputValue moveVal)
    {
        Vector2 direction = moveVal.Get<Vector2>();
        Debug.Log(direction);
        moveValue = direction;
        // Move(direction.x, direction.y);
        //TODO: store input as a 2D vector and call Move()

    }

    private void Move(float x, float z)
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
        // TODO: Set the x & z velocity of the Rigidbody to correspond with our inputs while keeping the y velocity what it originally is.

    }

    void OnCollisionEnter(Collision collision)
    {
        // This function is commonly useful, but for our current implementation we don't need it

    }

    void OnCollisionStay(Collision collision)
    {
        // TODO: Check if we are in contact with the ground. If we are, note that we are grounded

    }

    void OnCollisionExit(Collision collision)
    {
        // TODO: When we leave the ground, we are no longer grounded

    }

    private void Respawn()
    {
        // TODO: reload current scene

    }

    void OnPancake()
    {
        Pancake();
    }

    private void Pancake()
    {
        if (!pancaked)
        {
            Vector3 scale = transform.localScale;
            Vector3 newScale = new Vector3(scale.x * 2, scale.y / 2, scale.z * 2);
            pancaked = true;
            transform.localScale = newScale;
        }

    }
}
