using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    float cameraOffset = -20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
    }
}
