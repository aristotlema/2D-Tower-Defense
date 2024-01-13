using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _UI_buildMenu;

    private BuildMenuModel buildMenuModel;

    private void Awake()
    {
        buildMenuModel = new BuildMenuModel();
    }
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
        buildMenuModel.UpdateCurrentSelectedTile(tile);

        Debug.Log("Opening Build Menu");
        Debug.Log("Tile: " + tile);
        Debug.Log("TileStatus" + tileStatus);

        _UI_buildMenu.SetActive(true);
    }

    
}
