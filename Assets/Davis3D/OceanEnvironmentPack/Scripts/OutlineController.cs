using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class OutlineController : MonoBehaviour
{
    [SerializeField] private Shader outlineShader;
    [SerializeField] private Color outlineColor = Color.yellow;
    [SerializeField] private float outlineWidth = 0.08f;

    private Renderer targetRenderer;
    private Material[] originalMaterials;
    private Material[] outlineMaterials;
    private bool isUsingOutline = false;

    private void Awake()
    {
        targetRenderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Outline/SimpleOutline");

        // 保存原始材质
        originalMaterials = targetRenderer.sharedMaterials;

        // 创建用于描边的材质副本
        outlineMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < originalMaterials.Length; i++)
        {
            outlineMaterials[i] = new Material(originalMaterials[i]);
        }
    }

    // 切换到描边Shader
    public void ApplyOutline()
    {
        if (isUsingOutline) return;

        for (int i = 0; i < outlineMaterials.Length; i++)
        {
            outlineMaterials[i].shader = outlineShader;
            outlineMaterials[i].SetColor("_OutlineColor", outlineColor);
            outlineMaterials[i].SetFloat("_OutlineWidth", outlineWidth);
        }

        targetRenderer.materials = outlineMaterials;
        isUsingOutline = true;
    }

    // 恢复原始Shader
    public void RevertOutline()
    {
        if (!isUsingOutline) return;

        targetRenderer.materials = originalMaterials;
        isUsingOutline = false;
    }

    // 清理创建的新材质
    private void OnDestroy()
    {
        if (outlineMaterials != null)
        {
            foreach (var mat in outlineMaterials)
            {
                if (mat != null)
                {
                    Destroy(mat);
                }
            }
        }
    }
}