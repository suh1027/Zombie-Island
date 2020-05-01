using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab; // 단위 Quad 받아오기
    public Vector2 mapSize; // map 크기

    private void Start()
    {
        MapGenerate();    
    }

    private void MapGenerate()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0;  y < mapSize.y; y++)
            {
                // 타일의 위치를 잡고 새로운 타일을 생성
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 1.7f, -mapSize.y / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
            }
        }
    }

}
