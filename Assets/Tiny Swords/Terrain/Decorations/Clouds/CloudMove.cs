using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1f;
    public float rightLimit = 3.78f;
    public float leftLimit = -3.15f;
    private int direction = 1;

    [Header("Animation Settings")]
    // Các thông số đã được giảm mức tối thiểu để tạo độ mượt
    public float pulseAmplitude = 0.02f; 
    public float pulseSpeed = 0.3f;
    public float wobbleAmplitude = 0.05f;
    public float wobbleSpeed = 0.5f;

    private float startY;
    private Vector3 startScale;

    void Start()
    {
        startY = transform.localPosition.y;
        startScale = transform.localScale;
    }

    void Update()
    {
        // 1. Phần di chuyển
        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime, Space.Self);

        if (transform.localPosition.x >= rightLimit) direction = -1;
        else if (transform.localPosition.x <= leftLimit) direction = 1;

        // 2. Phần hoạt ảnh Procedural cực nhẹ
        float pulseFactor = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmplitude;
        transform.localScale = startScale * pulseFactor;

        float wobbleOffset = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmplitude;
        transform.localPosition = new Vector3(transform.localPosition.x, startY + wobbleOffset, transform.localPosition.z);
    }
}