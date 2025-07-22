using UnityEngine;

public class HoverSwitch : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;
    public GameObject objectE;
    public AudioSource bubble;

    void Start()
    {
        // 启动时自动隐藏 C 和 D
        objectA.SetActive(true);
        objectB.SetActive(true);
        objectC.SetActive(false);
        objectD.SetActive(false);
        objectE.SetActive(false);
    }

    //void OnMouseEnter()
    //{
    //    objectA.SetActive(false);
    //    objectB.SetActive(false);
    //    objectC.SetActive(true);
    //    objectD.SetActive(true);
    //}

    void OnMouseEnter()
    {
        Debug.Log("MouseEnter");

        objectA.SetActive(false);
        objectB.SetActive(false);
        objectC.SetActive(true);
        objectD.SetActive(true);
        objectE.SetActive(true);
        //bubble.Stop();
        bubble.Play();

        Debug.Log("A:" + objectC.activeSelf);
        Debug.Log("B:" + objectD.activeSelf);
        Debug.Log("C:" + objectC.activeSelf);
        Debug.Log("D:" + objectD.activeSelf);
        Debug.Log("E:" + objectD.activeSelf);
    }

    void OnMouseExit()
    {
        Debug.Log("MouseExit");

        objectA.SetActive(true);
        objectB.SetActive(true);
        objectC.SetActive(false);
        objectD.SetActive(false);
        objectE.SetActive(false);
        bubble.Stop();

        Debug.Log("A:" + objectC.activeSelf);
        Debug.Log("B:" + objectD.activeSelf);
        Debug.Log("C:" + objectC.activeSelf);
        Debug.Log("D:" + objectD.activeSelf);
        Debug.Log("E:" + objectD.activeSelf);
    }
}