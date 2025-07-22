using UnityEngine;

public class ParticleFishRepel : MonoBehaviour
{
    public ParticleSystem ps;
    public float repelRadius = 2f;   // ??????
    public float repelForce = 2f;    // ????

    private ParticleSystem.Particle[] particles;

    void Start()
    {
        // ???????
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    void Update()
    {
        int count = ps.GetParticles(particles);

        // ??????????????
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.nearClipPlane + 1f; // ????????
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        for (int i = 0; i < count; i++)
        {
            Vector3 dir = particles[i].position - mouseWorldPos;
            float dist = dir.magnitude;

            if (dist < repelRadius)
            {
                // ??????????
                dir.Normalize();
                float force = (repelRadius - dist) / repelRadius; // ??????
                particles[i].velocity += dir * repelForce * force * Time.deltaTime;
            }
        }

        // ??????????
        ps.SetParticles(particles, count);
    }
}

