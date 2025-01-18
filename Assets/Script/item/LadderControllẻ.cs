using UnityEngine;

public class LadderController : MonoBehaviour
{
    public float climbSpeed = 5f; // Tốc độ leo thang
    private Rigidbody2D rb;
    private bool isClimbing = false; // Kiểm tra nếu Player đang leo
    private float originalGravity; // Trọng lực gốc của Player

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale; // Lưu lại trọng lực ban đầu
    }

    private void Update()
    {
        // Kiểm tra nếu đang trong trạng thái leo thang
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical"); // Nhập phím lên/xuống
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed); // Di chuyển theo trục y
            rb.gravityScale = 0; // Tắt trọng lực khi leo thang
        }
        else
        {
            rb.gravityScale = originalGravity; // Phục hồi trọng lực khi không leo
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu Player chạm vào thang
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Kiểm tra nếu Player rời khỏi thang
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
}
