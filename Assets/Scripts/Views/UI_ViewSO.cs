using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CustomUI/ViewSO", fileName = "ViewSO")]
public class UI_ViewSO : ScriptableObject
{
    // [SerializeField] UI_ThemeSO theme;
    public RectOffset padding;
    public float spacing;

}
