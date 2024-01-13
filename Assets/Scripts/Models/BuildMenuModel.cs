using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuModel
{
    private Vector3Int _currentSelectedTile;
    private TileStatus _currentSelectedTileStatus;

    public BuildMenuModel() 
    { 
        
    }

    public Vector3Int GetCurrentSelectedTile()
    {
        return _currentSelectedTile;
    }

    public Vector3Int GetCurrentlSelectedTile()
    {
        return _currentSelectedTile;
    }
    public void UpdateCurrentSelectedTile(Vector3Int tile)
    {
        _currentSelectedTile = tile;
    }
}
