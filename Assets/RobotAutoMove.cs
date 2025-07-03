using UnityEngine;

public class RobotVacuum : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy input từ người chơi
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D hoặc ←/→
        float moveY = Input.GetAxisRaw("Vertical");   // W/S hoặc ↑/↓

        moveInput = new Vector2(moveX, moveY).normalized;

        // Xoay hướng robot theo hướng di chuyển
        if (moveInput != Vector2.zero)
        {
            transform.up = moveInput;
        }
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
