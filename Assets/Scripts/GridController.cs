using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

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
    [SerializeField] private UnityEvent openBuildMenu;

    public static event Action<Vector3Int, TileStatus> OnTileSelect;

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

    [SerializeField] private UI_BuildMenu buildMenuWindow;

    private BuildingController buildingController;

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
        if(!currentMousePosition.Equals(previousMousePosition))
        {
            interactiveMap.SetTile(previousMousePosition, null);
            interactiveMap.SetTile(currentMousePosition, hoverTileSprite);
            previousMousePosition = currentMousePosition;
        }

        BuildHandler();
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPosition);
    }

    private void BuildHandler()
    {
        //buildMenuWindow.buildBaseButton.onClick.AddListener(BuildTowerOnTile);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentSelectedTile = GetMousePosition();   

            OnTileSelect?.Invoke(currentSelectedTile, CheckTileStatus(currentSelectedTile));

            // Migrate to BuildMenu Controller

            //buildMenuWindow.gameObject.SetActive(true);
            //if (CheckIfTowerBaseIsBuilt())
            //{
            //    buildMenuWindow.SetBodyText("Tower Buildable");
            //    buildingController.BuildTower(GetMousePosition());
            //}
            //else if (!CheckIfTowerBaseIsBuilt() && !CheckIfFoliagePresent() && !CheckIfRoadPresent())
            //{
            //    buildMenuWindow.SetBodyText("You must build a tower base first");
            //    buildMenuWindow.SetBuildButtonText("Build base");

            //}
            //else if (CheckIfFoliagePresent())
            //{
            //    buildMenuWindow.SetBodyText("Clear the tree");
            //}
            //else if (CheckIfRoadPresent())
            //{
            //    buildMenuWindow.SetBodyText("You can't build on the road");
            //}
        }
    }

    private TileStatus CheckTileStatus(Vector3Int tile)
    {
        //Add for if tower fully built/ upgradeable
        if (TowerBasesMap.HasTile(tile))
            return TileStatus.TowerBase;
        else if (FoliageTileMap.HasTile(tile))
            return TileStatus.Clearable;
        else if (RoadTileMap.HasTile(tile))
            return TileStatus.NotBuildable;
        else if (!TowerBasesMap.HasTile(tile) && !FoliageTileMap.HasTile(tile) && !RoadTileMap.HasTile(tile))
            return TileStatus.Buildable;
        else
            Debug.LogError("issue with checking title status on grid controller");
            return TileStatus.NotBuildable;
    }

    private void BuildTowerOnTile()
    {
        TowerBasesMap.SetTile(currentSelectedTile, buildingController.BuildTowerBase());
    }
}
