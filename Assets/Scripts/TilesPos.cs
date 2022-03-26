using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPos : MonoBehaviour
{
    public GameObject[] Tiles;
    public int[][] tile = new int[10][];


    public void ListTiles()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tiles");
    }

    public void TilePos()
    {
        for (int i = 0; i < tile.Length; i++)
        {
            tile[i] = new int[10];
        }
        
        for (int i = 0; i < Tiles.Length; i++) //passage dans le tableau d'agent
        {
            for (int x = 0; x < tile.Length; x++) //tableau de position coordonnées x
            {
                for (int z = 0; z < tile[x].Length; z++) //tableau de position coordonnées z
                {
                    tile[x][z] += 1;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListTiles();
        TilePos();
    }
}
