using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class BuildMenuWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI windowTitleText;
    [SerializeField] private TextMeshProUGUI windowBodyText;

    public void SetBodyText(string message)
    {
        windowBodyText.text = message;
    }
}
