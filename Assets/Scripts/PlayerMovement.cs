using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        moveInput = Vector2.zero;

        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) moveInput.y += 1;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) moveInput.y -= 1;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) moveInput.x += 1;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) moveInput.x -= 1;

        moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed; // use rb.velocity on older Unity versions
    }
}