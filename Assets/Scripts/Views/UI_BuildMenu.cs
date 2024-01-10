using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_BuildMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI windowTitleText;
    [SerializeField] private TextMeshProUGUI windowBodyText;

    [Header("Buttons")]
    [SerializeField] private TextMeshProUGUI buildBaseButtonText;
    [SerializeField] public Button buildBaseButton;


    public void SetBodyText(string message)
    {
        windowBodyText.text = message;
    }

    public void SetBuildButtonText(string message)
    {
        buildBaseButtonText.text = message;
    }
}