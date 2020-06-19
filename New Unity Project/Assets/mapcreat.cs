using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapcreat : MonoBehaviour
{
    public Tilemap tilemap;//引用的Tilemap，加入脚本后需要将对应tilemap拖进来
    public Tilemap bgmap;//引用的Tilemap，加入脚本后需要将对应tilemap拖进来
    private Dictionary<string, Tile> arrTiles; //地块种类
    private List<string> TilesName;
    string[] TileType;
    string[] TileType_basis;
    //大地图宽高
    public int levelW;
    public int levelH;
    public int city = 1;
    public int village = 3;
    public int mine = 3;
    public int stone = 5;
    // Start is called before the first frame update
    void Start()
    {
        arrTiles = new Dictionary<string, Tile>();
        TilesName = new List<string>();
        InitTile();
        InitMapTilesInfo();
        InitMapbasisInfo();
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
                bgmap.SetTile(new Vector3Int(j, i, 0), arrTiles[TileType_basis[i * levelW + j]]);

            }
        }
    }

    void InitMapTilesInfo()
    {
        //初始化地图信息，即每个单位对应的地面类型
        TileType = new string[levelH * levelW];
        int check = 0;
        int city_c = 0;
        int village_c = 0;
        int mine_c = 0;
        int stone_c = 0;
        int dikuai;
        for (int i = 0; i < levelH; i++)
        {
            for (int j = 0; j < levelW; j++)
            {
                check = 0;
                dikuai = Randmap();
                    //Random.Range(1, TilesName.Count);

                while (check == 0)
                {
                    switch (dikuai)
                    {
                        case 102://石山
                            if (stone_c < stone)
                            {
                                check = 1;
                                stone_c++;
                            }
                            else
                            {
                                check = 0;
                            }
                            break;
                        case 103://矿山
                            if (mine_c < mine)
                            {
                                check = 1;
                                mine_c++;
                            }
                            else
                            {
                                check = 0;
                            }
                            break;
                        case 2101://村庄
                            if (village_c < village)
                            {
                                check = 1;
                                village_c++;
                            }
                            else
                            {
                                check = 0;
                            }
                            break;
                        case 2102://城市
                            if (city_c < city)
                            {
                                check = 1;
                                city_c++;
                            }
                            else
                            {
                                check = 0;
                            }
                            break;
                        default:
                            check = 1;
                            break;
                    }
                    if (check == 0)
                    {
                        dikuai = Randmap();
                    }
                }
                TileType[i * levelW + j] = dikuai.ToString();
                Debug.Log("dikuai:" + dikuai);
            }
        }
    }
    void InitMapbasisInfo()
    {
        //初始化地图信息，即每个单位对应的地面类型
        TileType_basis = new string[levelH * levelW];
        for (int i = 0; i < levelH; i++)
        {
            for (int j = 0; j < levelW; j++)
            {
                TileType_basis[i * levelW + j] = TilesName[0];
            }
        }
    }

    void InitTile()
    {
        foreach (var info in Configinit.Config_Map)
        {
            AddTile(info.Value.id.ToString(), info.Value.pic);
            Debug.Log(info.Key + " " + info.Value.pic);
        }
        //Configinit.Config_Map[type].pic
        //创建3钟类型的地面瓦片
        //AddTile("soil", "map/map_100");
        //AddTile("brick", "map/map_101");
        //AddTile("grass", "map/map_102");

    }

    void AddTile(string labelName, string spritePath)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();//创建Tile，注意，要使用这种方式
        Sprite tmp = Resources.Load<Sprite>(spritePath);
        tile.sprite = tmp;
        arrTiles.Add(labelName, tile);
        TilesName.Add(labelName);

    }
    private int Randmap()
    {
        int maxweight=0;
        Dictionary<int,int> weightlist=new Dictionary<int, int>();
        foreach (var info in Configinit.Config_Map)
        {
            maxweight = maxweight + info.Value.weight;
            //Debug.Log(info.Key + " " + info.Value.pic);
            weightlist.Add( maxweight, info.Value.id);
        }
        int weight=Random.Range(1, maxweight);
        int mat = maxweight;
        foreach (var info in weightlist)
        {
            if  (weight<= info.Key )
            {
                if (info.Key <= mat)
                {
                    mat = info.Key;
                }

            }
            
        }
        return weightlist[mat];
    }
}
