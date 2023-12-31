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

    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tile hoverTileSprite;

    private BuildingController buildingController;
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        buildingController = FindAnyObjectByType<BuildingController>();
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

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tileMapPositon = grid.WorldToCell(mouseWorldPosition);
            Debug.Log(grid.CellToWorld(tileMapPositon));

            buildingController.BuildTower(grid.CellToWorld(tileMapPositon));
        }
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPosition);
    }
}
