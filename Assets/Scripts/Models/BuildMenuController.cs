using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BuildMenuController : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private GameObject _UI_buildMenu;

    private BuildMenuModel _buildMenuModel;


    private void Awake()
    {
        _buildMenuModel = new BuildMenuModel();
    }
    private void OnEnable()
    {
        GridController.OnTileSelect += OpenBuildMenu;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= OpenBuildMenu;
    }
    private void OpenBuildMenu(CustomTile tile)
    {
        _buildMenuModel.UpdateCurrentSelectedTile(tile);

        Debug.Log("Opening Build Menu");
        Debug.Log("Tile: " + tile.Coordiantes);
        Debug.Log("TileStatus" + tile.TileStatus);

        _UI_buildMenu.SetActive(true);
    }
}
