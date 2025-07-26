using System.Collections;
using UnityEngine;

public class LightToggleByDistance : MonoBehaviour
{
    public Transform jellyfish;         // 海蜇的 Transform
    public Transform mainCamera;        // 主摄像机的 Transform
    public float triggerDistance = 5f;  // 距离阈值，单位是米

    public Light pointLight;
    public FloatingText flotT;

    void Start()
    {
        pointLight = GetComponent<Light>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(mainCamera.position, jellyfish.position);
        pointLight.enabled = distance < triggerDistance;
    }

    void OnMouseEnter()
    {


        if (flotT != null)
        {
            flotT.gameObject.SetActive(true);
        }

    }

    void OnMouseExit()
    {


        if (flotT != null)
        {
            flotT.gameObject.SetActive(false);
        }


    }
}
