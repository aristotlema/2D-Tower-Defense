using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//useful link
//https://lukashermann.dev/writing/unity-highlight-tile-in-tilemap-on-mousever/


public class GridController : MonoBehaviour
{
    private Grid grid;

    private Vector3Int previousMousePosition = new Vector3Int();
    private Vector3Int currentMousePosition;

    [Header("Tilemaps/Tiles")]
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap TowerBasesMap = null;
    [SerializeField] private Tilemap FoliageTileMap = null;
    [SerializeField] private Tilemap RoadTileMap = null;
    [SerializeField] private Tile hoverTileSprite;

    [SerializeField] private BuildMenuWindow buildMenuWindow;

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
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPosition);
    }

    private bool CheckIfTowerBaseIsBuilt()
    {
        return TowerBasesMap.HasTile(GetMousePosition());
    }

    private bool CheckIfFoliagePresent()
    {
        return FoliageTileMap.HasTile(GetMousePosition());
    }

    private bool CheckIfRoadPresent()
    {
        return RoadTileMap.HasTile(GetMousePosition());
    }

    private void BuildHandler()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            buildMenuWindow.gameObject.SetActive(true);
            if (CheckIfTowerBaseIsBuilt())
            {
                buildMenuWindow.SetBodyText("Tower Buildable");
                buildingController.BuildTower(GetMousePosition());
            }
            else if (!CheckIfTowerBaseIsBuilt() && !CheckIfFoliagePresent() && !CheckIfRoadPresent())
            {
                buildMenuWindow.SetBodyText("You must build a tower base first");
            }
            else if (CheckIfFoliagePresent())
            {
                buildMenuWindow.SetBodyText("Clear the tree");
            }
            else if (CheckIfRoadPresent())
            {
                buildMenuWindow.SetBodyText("You can't build on the road");
            }
        }
    }
}
