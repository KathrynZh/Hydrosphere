using UnityEngine;

public class BubbleAmbientSound : MonoBehaviour
{
    public AudioSource bubbleSound;
    public float playDistance = 10f;

    private Transform mainCameraTransform;
    private bool isPlaying = false;

    void Start()
    {
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Main Camera not found!");
        }
    }

    void Update()
    {
        if (mainCameraTransform == null) return;

        float distance = Vector3.Distance(transform.position, mainCameraTransform.position);

        if (distance <= playDistance && !isPlaying)
        {
            bubbleSound.Play();
            isPlaying = true;
        }
        else if (distance > playDistance && isPlaying)
        {
            bubbleSound.Stop();
            isPlaying = false;
        }
    }
}

