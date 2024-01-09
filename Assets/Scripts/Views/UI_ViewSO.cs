using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ViewSO : ScriptableObject
{
    // [SerializeField] UI_ThemeSO theme;
    public RectOffset padding { get; private set; }
    public float spacing { get; private set; } 

}
