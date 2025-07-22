using UnityEngine;

public class SplineWalker : MonoBehaviour
{
    public BezierSpline spline;
    public float duration;
    public bool lookForward;
    public bool loop;

    public bool isPaused = false;

    private float progress;
    private bool goingForward = true;

    void Update()
    {
        if (isPaused) return;

        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;

        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
}
