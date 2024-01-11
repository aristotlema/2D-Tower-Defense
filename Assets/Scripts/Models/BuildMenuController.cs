using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuController : MonoBehaviour
{
    [SerializeField] private GameObject buildMenu;

    private Vector3Int _currentSelectedTile;
    private TileStatus _currentSelectedTileStatus;
    private string _buildDisplayText;

    // Build a tower base
    // Build a turret
    // clear space

    private void OnEnable()
    {
        GridController.OnTileSelect += OpenBuildMenu;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= OpenBuildMenu;
    }
    private void OpenBuildMenu(Vector3Int tile, TileStatus tileStatus)
    {
        _currentSelectedTile = tile;
        _currentSelectedTileStatus = tileStatus;

        Debug.Log("Opening Build Menu");
        Debug.Log("Tile: " + tile);
        Debug.Log("TileStatus" + tileStatus);

        buildMenu.SetActive(true);
    }

    
}
