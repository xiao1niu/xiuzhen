using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapcreat : MonoBehaviour
{
    public Tilemap tilemap;//引用的Tilemap，加入脚本后需要将对应tilemap拖进来
    private Dictionary<string, Tile> arrTiles; //地块种类
    private List<string> TilesName;
    string[] TileType;
    //大地图宽高
    public int levelW = 10;
    public int levelH = 10;
    // Start is called before the first frame update
    void Start()
    {
        arrTiles = new Dictionary<string, Tile>();
        TilesName = new List<string>();
        InitTile();
        InitMapTilesInfo();
        InitData();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitData()
    {
        for (int i = 0; i < levelH; i++)
        {//根据地面类型TileType初始化tilemap
            for (int j = 0; j < levelW; j++)
            {
                tilemap.SetTile(new Vector3Int(j, i, 0), arrTiles[TileType[i * levelW + j]]);
            }
        }
    }

    void InitMapTilesInfo()
    {
        //初始化地图信息，即每个单位对应的地面类型
        TileType = new string[levelH * levelW];
        for (int i = 0; i < levelH; i++)
        {
            for (int j = 0; j < levelW; j++)
            {
                TileType[i * levelW + j] = TilesName[Random.Range(0, TilesName.Count)];
            }
        }
    }

    void InitTile()
    {
        //创建3钟类型的地面瓦片
        AddTile("soil", "map/map_100");
        AddTile("brick", "map/map_101");
        AddTile("grass", "map/map_102");

    }

    void AddTile(string labelName, string spritePath)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();//创建Tile，注意，要使用这种方式
        Sprite tmp = Resources.Load<Sprite>(spritePath);
        tile.sprite = tmp;
        arrTiles.Add(labelName, tile);
        TilesName.Add(labelName);

    }
}
