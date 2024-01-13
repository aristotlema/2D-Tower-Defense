using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuModel
{
    private Vector3Int _OLDcurrentSelectedTile;
    private CustomTile _currentSelectedTile;

    public CustomTile CurrentSelectedTile { get => _currentSelectedTile; set => _currentSelectedTile = value; }

    public event Action SelectedTileChanged;

    public void UpdateCurrentSelectedTile(CustomTile tile)
    {
        _currentSelectedTile = tile;
        UpdateTile();
    }

    private void UpdateTile()
    {
        SelectedTileChanged?.Invoke();
    }
}
