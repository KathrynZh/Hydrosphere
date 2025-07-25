using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private string nameValue;
    public TextMeshPro textname;
    void Awake()
    {
        cam = Camera.main;
        
    }

    void OnEnable()
    {
        textname.text = nameValue;
        
    }
    
     void OnDisable()
    {
        textname.text = string.Empty;
    }

     void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.LookAt(cam.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
