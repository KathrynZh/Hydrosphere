using UnityEngine;
using UnityEngine.VFX;

public class BubbleVFX : MonoBehaviour
{
    public float lifetime = 1f;
    public float riseSpeed = 0.5f;

    private VisualEffect vfx;
    private float timer = 0f;

    void Start()
    {
        vfx = GetComponent<VisualEffect>();
        vfx.Play();
    }

    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
