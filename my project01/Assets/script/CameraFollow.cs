using UnityEngine;

public class CameraFllow : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D playerRb;

    [Header("Follow Settings")]
    public Vector3 offset;
    public float normalSmoothTime = 0.3f;   // 평상시 추적 속도
    public float fastSmoothTime = 0.05f;    // 낙하 시 추적 속도
    public float fallThreshold = -5f;      // 낙하 판정 속도

    [Header("Ground Check")]
    public float groundDistance = 1.1f;    // 바닥 체크 거리
    public LayerMask groundLayer;          // 바닥 레이어 설정

    private Vector3 currentVelocity = Vector3.zero;
    private bool isFallingMode = false;    // 현재 낙하 모드인지 여부

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;

        // 1. 바닥 상태 확인
        bool isGrounded = Physics.Raycast(player.position, Vector3.down, groundDistance, groundLayer);

        // 2. 모드 전환 로직 (낙하 시작 시 모드 ON / 바닥 닿으면 모드 OFF)
        if (!isGrounded && playerRb.linearVelocity.y < fallThreshold)
        {
            isFallingMode = true; // 빠르게 떨어지면 낙하 모드 활성화
        }
        
        if (isGrounded)
        {
            isFallingMode = false; // 땅에 닿는 순간 낙하 모드 즉시 해제
        }

        // 3. 현재 모드에 따른 부드러움(SmoothTime) 결정
        // 낙하 모드면 fastSmoothTime을, 아니면 normalSmoothTime을 사용합니다.
        float currentSmooth = isFallingMode ? fastSmoothTime : normalSmoothTime;

        // 4. 카메라 이동 실행
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            targetPosition, 
            ref currentVelocity, 
            currentSmooth
        );
    }
    
}
