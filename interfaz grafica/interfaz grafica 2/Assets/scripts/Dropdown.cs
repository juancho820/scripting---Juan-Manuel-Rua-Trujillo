﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public RectTransform container;
    public bool isOpen;

    // Use this for initialization
    void Start () {
        container = transform.Find("Container").GetComponent<RectTransform>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
            Vector3 scale = container.localScale;
            scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
            container.localScale = scale;

	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }
}
