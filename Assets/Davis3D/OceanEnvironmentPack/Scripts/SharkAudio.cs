using System.Collections;
using UnityEngine;

public class SharkAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public SplineWalker splineWalker;

    public float minPlayDistance = 10f; // ?????????
    public float maxPlayDistance = 20f; // ?????????

    //public float fadeDuration = 2f;     // ??????

    private Transform mainCameraTransform;
    //private Coroutine fadeCoroutine;    // ?????????????????

    public OutlineController oc;

    void Start()
    {
        splineWalker = GetComponent<SplineWalker>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Debug.Log(audioSource.volume);
    }

    void OnMouseEnter()
    {
        float distance = Vector3.Distance(transform.position, mainCameraTransform.position);
        oc.ApplyOutline();

        if (distance <= minPlayDistance)
        {
            // ????
            if (splineWalker != null)
                splineWalker.isPaused = true;
        }
    }

    void OnMouseDown()
    {
        float distance = Vector3.Distance(transform.position, mainCameraTransform.position);

        if (distance <= minPlayDistance)
        {
            // ??????
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
    }

    void OnMouseExit()
    {
        oc.RevertOutline();
        // ????
        if (splineWalker != null)
            splineWalker.isPaused = false;
    }
}