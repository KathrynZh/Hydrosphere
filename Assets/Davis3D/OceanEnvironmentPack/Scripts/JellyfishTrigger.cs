using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class JellyfishRiseOnProximity : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isRising = false;

    [Header("浮动设置")]
    public float riseHeight = 1.5f;    // 上升高度
    public float riseSpeed = 2.0f;     // 上浮速度

    void Start()
    {
        // 记录水母初始位置
        startPosition = transform.position;
        targetPosition = startPosition;

        // 设置触发器
        SphereCollider col = GetComponent<SphereCollider>();
        col.isTrigger = true;
        col.radius = 3f;
    }

    void Update()
    {
        // 每帧将水母移动到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * riseSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRising = true;
            targetPosition = startPosition + new Vector3(0, riseHeight, 0); // 上升目标
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRising = false;
            targetPosition = startPosition; // 回到原位
        }
    }
}
