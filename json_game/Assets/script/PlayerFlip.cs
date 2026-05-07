using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 객체에 붙어있는 SpriteRenderer 컴포넌트를 가져옵니다.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 'd'를 누르면 오른쪽을 봄 (반전 해제)
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        // 'a'를 누르면 왼쪽을 봄 (반전 설정)
        else if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
    }
}
