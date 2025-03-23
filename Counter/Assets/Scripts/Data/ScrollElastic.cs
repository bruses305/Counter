using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollElastic : MonoBehaviour
{
    private float Strenght = 5;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    public void Elastic()
    {
        if (rectTransform.anchoredPosition.y<0) {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, Vector2.zero,Time.deltaTime * Strenght);
        }
    }
}
