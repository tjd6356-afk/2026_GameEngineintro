using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections; // 코루틴 사용을 위해 필요

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Stun Settings")]
    public float landStunTime = 3f;  // 착지 시 멈춤 시간

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool wasGrounded;          // 이전 프레임의 땅 접지 상태
    private bool canMove = true;       // 이동 가능 여부 플래그
    private float moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   private void Update()
   {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && !wasGrounded && rb.linearVelocity.y <= 0)
        {
            StartCoroutine(StunRoutine(landStunTime));
        }
        if (canMove)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // 멈춰있을 때는 X축 속도를 0으로 고정
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        wasGrounded = isGrounded; // 상태 업데이트
   }

   public void OnMove(InputValue value)
   {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
   }

   public void OnJump(InputValue value)
   {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
   }

   // 일시 정지 로직 (코루틴)
    private IEnumerator StunRoutine(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("PlayScene_" + collision.name);
        }

        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
