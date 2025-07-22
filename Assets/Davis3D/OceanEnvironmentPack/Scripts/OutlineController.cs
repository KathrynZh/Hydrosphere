<<<<<<< HEAD
﻿using UnityEngine;
=======
using UnityEngine;
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e

[RequireComponent(typeof(Renderer))]
public class OutlineController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Shader outlineShader;
    [SerializeField] private Color outlineColor = Color.yellow;
    [SerializeField] private float outlineWidth = 0.08f;

=======
    [SerializeField] private Shader outlineShader = null;
    [SerializeField] private Color outlineColor = Color.white;
    [SerializeField] private float outlineWidth = 0.05f;
    
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
    private Renderer targetRenderer;
    private Material[] originalMaterials;
    private Material[] outlineMaterials;
    private bool isUsingOutline = false;
<<<<<<< HEAD

    private void Awake()
    {
        targetRenderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Outline/SimpleOutline");

        // 保存原始材质
        originalMaterials = targetRenderer.sharedMaterials;

=======
    
    private void Awake()
    {
        targetRenderer = GetComponent<Renderer>();
        
        // 保存原始材质
        originalMaterials = targetRenderer.sharedMaterials;
        
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
        // 创建用于描边的材质副本
        outlineMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < originalMaterials.Length; i++)
        {
            outlineMaterials[i] = new Material(originalMaterials[i]);
        }
    }
<<<<<<< HEAD

=======
    
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
    // 切换到描边Shader
    public void ApplyOutline()
    {
        if (isUsingOutline) return;
<<<<<<< HEAD

=======
        
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
        for (int i = 0; i < outlineMaterials.Length; i++)
        {
            outlineMaterials[i].shader = outlineShader;
            outlineMaterials[i].SetColor("_OutlineColor", outlineColor);
            outlineMaterials[i].SetFloat("_OutlineWidth", outlineWidth);
        }
<<<<<<< HEAD

        targetRenderer.materials = outlineMaterials;
        isUsingOutline = true;
    }

=======
        
        targetRenderer.materials = outlineMaterials;
        isUsingOutline = true;
    }
    
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
    // 恢复原始Shader
    public void RevertOutline()
    {
        if (!isUsingOutline) return;
<<<<<<< HEAD

        targetRenderer.materials = originalMaterials;
        isUsingOutline = false;
    }

=======
        
        targetRenderer.materials = originalMaterials;
        isUsingOutline = false;
    }
    
>>>>>>> 79b03bb70605300b318c2dfc3435d78931e8fd1e
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