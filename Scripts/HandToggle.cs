using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandToggle : MonoBehaviour
{
    [SerializeField] private GameObject leftControls, rightControls;
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        
        int savedHandValue = PlayerPrefs.GetInt("HandValue", 1);
        toggle.isOn = savedHandValue == 1;

        UpdateControlsVisibility(); 
    }

    private void Update()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("HandValue", 1);
        }
        else
        {
            PlayerPrefs.SetInt("HandValue", 0);
        }

        UpdateControlsVisibility();
    }

    private void UpdateControlsVisibility()
    {
        rightControls.SetActive(toggle.isOn);
        leftControls.SetActive(!toggle.isOn);
    }
}
