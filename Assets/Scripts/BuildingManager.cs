using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    // Listen for build events that return a GameTile
    // Have a link to controllers needed for building
    private GridController _gridController;
    private BuildingController _buildingController;
    private BuildMenuController _buildMenuController;

    private void OnEnable()
    {
        Init();
        UI_BuildMenuViewModel.OnBuildTower += BuildTowerBase;
    }

    private void OnDisable()
    {
        UI_BuildMenuViewModel.OnBuildTower -= BuildTowerBase;
    }

    //Clean up in Grid Controller
    //Building Controller

    public void BuildTowerBase(GameTile tile)
    {
        Debug.Log("Clicked");
        var tileBase = _buildingController.GetTowerBaseTile();
        _gridController.PlaceTowerTileBaseOnGrid(tile, tileBase);
        // Get Base Tile
        // Add it to the Grid at location
        // Add Tile to the Tower Array ****
        // Update the Game Tiles status
        tile.TileStatus = _gridController.GetTileStatus(tile.Coordiantes);
        // Withdraw Currency
        // After completed, for refresh on Build Menu UI/Selected Tile
        _buildMenuController.RefreshCurrentSelectedTile(tile);
    }
        
    //BuildTurret
    //Clear Foliage

    private void Init()
    {
        _gridController = FindAnyObjectByType<GridController>();
        _buildingController = FindAnyObjectByType<BuildingController>();
        _buildMenuController = FindAnyObjectByType<BuildMenuController>();
    }
}
