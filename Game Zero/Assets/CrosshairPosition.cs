using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPosition : MonoBehaviour
{
    public Transform crosshairTarget;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.position = crosshairTarget.position;
        // new Vector2 (crosshairTarget.position.x, crosshairTarget.position.y);
    }
}
