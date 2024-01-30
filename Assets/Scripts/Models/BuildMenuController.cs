using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuController : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private GameObject _UI_buildMenu;
    
    //Model - non mono behavior
    private BuildMenuModel _buildMenuModel;

    [Header("Buttons")]
    [SerializeField] private Button _buildTurret;
    [SerializeField] private Button _buildTower;
    [SerializeField] private Button _clearTile;

    private void Awake()
    {
        _buildMenuModel = new BuildMenuModel();
    }

    private void OnEnable()
    {
        GridController.OnTileSelect += OpenBuildMenu;
        BuildMenuModel.SelectedTileChanged += OnSelectedTileChanged;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= OpenBuildMenu;
        BuildMenuModel.SelectedTileChanged -= OnSelectedTileChanged;
    }
    private void OpenBuildMenu(GameTile tile)
    {
        _buildMenuModel.UpdateCurrentSelectedTile(tile);
        _UI_buildMenu.SetActive(true);
        Debug.Log("Opening Build Menu" + "Tile: " + tile.Coordiantes + "TileStatus" + tile.TileStatus);
    }

    public void RefreshCurrentSelectedTile(GameTile tile)
    {
        _buildMenuModel.UpdateCurrentSelectedTile(tile);
    }

    private void UpdateView()
    {
        if(_buildMenuModel == null) return;
    }

    private void OnSelectedTileChanged(GameTile t)
    {
        UpdateView();
    }
}
