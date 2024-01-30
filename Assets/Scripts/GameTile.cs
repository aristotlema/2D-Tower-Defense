using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    public Vector3Int Coordiantes { get; set; }
    public TileStatus TileStatus { get; set; }

    public GameTile(Vector3Int coordiantes, TileStatus tileStatus)
    {
        this.Coordiantes = coordiantes;
        this.TileStatus = tileStatus;
    }
}
