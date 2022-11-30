using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionBar : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject canvasGameObject;
    [SerializeField] private Gradient gradientColor;
    [SerializeField] private Image fill;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        fill.color = gradientColor.Evaluate(0.5f);
    }

    void LateUpdate()
    {
        transform.LookAt(canvasGameObject.transform.position + cameraTransform.forward);
    }
}
