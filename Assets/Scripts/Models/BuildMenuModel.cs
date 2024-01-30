using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuModel
{
    public GameTile CurrentSelectedTile { get; private set; }

    public static event Action<GameTile> SelectedTileChanged;

    public void UpdateCurrentSelectedTile(GameTile tile)
    {
        CurrentSelectedTile = tile;
        UpdateTile(tile);
    }

    private void UpdateTile(GameTile tile)
    {
        SelectedTileChanged?.Invoke(tile);
    }
}
