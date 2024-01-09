using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_View : CustomUIComponent
{
    [SerializeField] private UI_ViewSO viewData;

    private VerticalLayoutGroup verticalLayoutGroup;

    public override void Setup()
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    public override void Configure()
    {
        verticalLayoutGroup.padding = viewData.padding;
        verticalLayoutGroup.spacing = viewData.spacing;
    }
}
