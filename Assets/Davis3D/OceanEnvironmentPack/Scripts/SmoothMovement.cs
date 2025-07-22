using UnityEngine;

/// <summary>
/// 更真实的水下漂浮相机控制器：
/// - 平滑移动（SmoothDamp）
/// - 上下浮动感（漂浮）
/// - 自由视角旋转（右键）
/// </summary>
public class SmoothSwimCamera : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float fastMovementSpeed = 20f;
    public float freeLookSensitivity = 3f;
    public float zoomSensitivity = 10f;
    public float fastZoomSensitivity = 50f;
    public float smoothingTime = 0.3f; // 平滑时间

    private bool looking = false;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
        StartLooking();
    }

    void Update()
    {
        bool fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float speed = fastMode ? fastMovementSpeed : movementSpeed;

        Vector3 inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) inputDirection += -transform.right;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) inputDirection += transform.right;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) inputDirection += transform.forward;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) inputDirection += -transform.forward;
        if (Input.GetKey(KeyCode.E)) inputDirection += transform.up;
        if (Input.GetKey(KeyCode.Q)) inputDirection += -transform.up;
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp)) inputDirection += Vector3.up;
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown)) inputDirection += -Vector3.up;

        // 鼠标滚轮推进
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float zoomSpeed = fastMode ? fastZoomSensitivity : zoomSensitivity;
            inputDirection += transform.forward * scroll * zoomSpeed;
        }

        // 更新目标位置
        targetPosition += inputDirection.normalized * speed * Time.deltaTime;


        // 平滑移动 + 加漂浮感
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothingTime);

        // 视角旋转（自由视角）
        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }
    }

    private void OnDisable()
    {
        StopLooking();
    }

    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
