using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//useful link
//https://lukashermann.dev/writing/unity-highlight-tile-in-tilemap-on-mousever/

public enum TileStatus
{
    Upgradeable,
    TowerBase,
    Buildable,
    Clearable,
    NotBuildable
}

public class GridController : MonoBehaviour
{
    public static event Action<GameTile> OnTileSelect;

    private Grid grid;

    private Vector3Int previousMousePosition = new Vector3Int();
    private Vector3Int currentMousePosition;
    private Vector3Int currentSelectedTile;

    [Header("Tilemaps/Tiles")]
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap TowerBasesMap = null;
    [SerializeField] private Tilemap FoliageTileMap = null;
    [SerializeField] private Tilemap RoadTileMap = null;
    [SerializeField] private Tile hoverTileSprite;

    //[SerializeField] private UI_BuildMenu buildMenuWindow;

    private BuildingController buildingController;

    //private void OnEnable()
    //{
    //    UI_BuildMenuViewModel.OnBuildTower += BuildTowerOnTile;
    //}
    //private void OnDisable()
    //{
    //    UI_BuildMenuViewModel.OnBuildTower -= BuildTowerOnTile;
    //}


    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        buildingController = FindAnyObjectByType<BuildingController>();
        hoverTileSprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePosition = GetMousePosition();
        TileHighlightHandler();
        GridInputHandler();
    }

    private void TileHighlightHandler()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            interactiveMap.SetTile(previousMousePosition, null);
        }
        else
        {
            if (!currentMousePosition.Equals(previousMousePosition))
            {
                interactiveMap.SetTile(previousMousePosition, null);
                interactiveMap.SetTile(currentMousePosition, hoverTileSprite);
                previousMousePosition = currentMousePosition;
            }
        }
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPosition);
    }

    private void GridInputHandler()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            currentSelectedTile = GetMousePosition();   

            OnTileSelect?.Invoke(new GameTile(currentSelectedTile, GetTileStatus(currentSelectedTile)));
        }
    }

    public TileStatus GetTileStatus(Vector3Int tile)
    {
        //Add for if tower fully built/ upgradeable
        if (TowerBasesMap.HasTile(tile))
            return TileStatus.TowerBase;
        else if (FoliageTileMap.HasTile(tile))
            return TileStatus.Clearable;
        else if (RoadTileMap.HasTile(tile))
            return TileStatus.NotBuildable;
        else if (interactiveMap.HasTile(tile) && !TowerBasesMap.HasTile(tile) && !FoliageTileMap.HasTile(tile) && !RoadTileMap.HasTile(tile))
            return TileStatus.Buildable;
        else
            Debug.LogError("issue with checking title status on grid controller");
            return TileStatus.NotBuildable;
    }

    public void PlaceTowerTileBaseOnGrid(GameTile tile, Tile tileBase)
    {
        TowerBasesMap.SetTile(tile.Coordiantes, tileBase);
    }
}
