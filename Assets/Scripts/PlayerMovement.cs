using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 moveDirection;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Stop();

        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        if (Input.GetKey(KeyCode.D))
            MoveRight();
        if (Input.GetKey(KeyCode.S))
            MoveDown();
        if (Input.GetKey(KeyCode.W))
            MoveUp();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * moveSpeed;
    }

    private void Stop()
    {
        moveDirection = Vector2.zero;
    }

    private void MoveLeft()
    {
        moveDirection = new Vector2(-1, moveDirection.y);
    }

    private void MoveRight()
    {
        moveDirection = new Vector2(1, moveDirection.y);
    }

    private void MoveDown()
    {
        moveDirection = new Vector2(moveDirection.x, -1);
    }

    private void MoveUp()
    {
        moveDirection = new Vector2(moveDirection.x, 1);
    }
}