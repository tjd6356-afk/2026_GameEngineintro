using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public float duration = 5f;          // 지속 시간
    public float speedMultiplier = 2f;   // 속도 증가 배수

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 대상이 "Player" 태그를 가지고 있는지 확인
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                // 플레이어에게 아이템 효과 적용
                player.ApplyPowerUp(duration, speedMultiplier);

                // 아이템 오브젝트 파괴
                Destroy(gameObject);
            }
        }
    }
}
