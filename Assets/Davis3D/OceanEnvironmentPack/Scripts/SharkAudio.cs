﻿using System.Collections;
using UnityEngine;

public class SharkAudio : MonoBehaviour
{
    public AudioSource audioSource;  // 主讲解音频
    public AudioSource hover;        // 鼠标悬停音效
    public AudioSource click;        // 鼠标点击音效
    public SplineWalker splineWalker;

    private Transform mainCameraTransform;
    public OutlineController oc;
    public FloatingText flotT;

    private bool isClicking = false; // 防止重复点击触发

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.StopAll();
        }
    }

    void OnMouseEnter()
    {
        oc.ApplyOutline();

        if (flotT != null)
        {
            flotT.gameObject.SetActive(true);
        }

        if (splineWalker != null)
        {
            splineWalker.isPaused = true;
        }

        if (hover != null)
        {
            hover.Stop(); // 先停止，确保每次都能重新播放
            StartCoroutine(PlayHoverClipPartially());
        }
    }

    void OnMouseDown()
    {
        if (audioSource != null && !audioSource.isPlaying && !isClicking)
        {
            StartCoroutine(PlayClickThenMainAudio());
        }
    }

    IEnumerator PlayClickThenMainAudio()
    {
        isClicking = true;

        if (click != null && click.clip != null)
        {
            click.Stop();
            click.Play();
            yield return new WaitForSeconds(0.6f);
        }

        if (audioSource != null)
        {
            AudioManager.Instance.PlayExclusive(audioSource);
        }

        isClicking = false;
    }

    void OnMouseExit()
    {
        oc.RevertOutline();
        
        if (flotT != null)
        {
            flotT.gameObject.SetActive(false);
        }

        if (splineWalker != null)
        {
            splineWalker.isPaused = false;
        }
    }

    IEnumerator PlayHoverClipPartially()
    {
        hover.time = 0f;
        hover.Play();
        yield return new WaitForSeconds(0.6f);
        hover.Pause(); // 暂停播放剩余部分
    }
}

