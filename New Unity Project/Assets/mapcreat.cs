using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
    public float _maxHeight = 15;
    public float _relief = 10f;

    private float _seedX, _seedZ;
    public int city = 10;
    public int village = 30;
    public int mine = 80;
    public int stone = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        TileType = new string[levelH * levelW];
        arrTiles = new Dictionary<string, Tile>();
        TilesName = new List<string>();
        InitTile();
        InitMapbasisInfo();
        if (!File.Exists(Application.dataPath + "/save/map.txt"))
        {

            InitMapTilesInfo();
            //Savemap();
        }
        else {
            gamedata_Map mapdata =Loadmap();
            foreach (var info in mapdata.map)
            {
                //Debug.Log(info.Key);
                TileType[Convert.ToInt32(info.Key)] = info.Value.mapdetail.ToString();
            }   
        }
        InitData();

    }

    // Update is called once per frame
    void Update()
    {
    }
    void Savemap(gamedata_Map mapdata)
    {
        mapdata.mapname = "map" + ".txt";
        string filePath = Application.dataPath + "/save/"+ mapdata.mapname;
        string json = JsonMapper.ToJson(mapdata);
        //string json = JsonUtility.ToJson(mapdata);
        byte[] data = System.Text.Encoding.Default.GetBytes(json);
        //BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                //FileStream file = File.Create(Application.dataPath + "/save/" + mapdata.mapname);
                //Debug.Log(json);
                fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            //bf.Serialize(file, json);
            //file.Close();
            //Debug.Log("Saving as JSON: " + json);
            // Debug.Log("Game Saved "+ save.name);
        }

    }
    gamedata_Map Loadmap()
    {
        string filePath = Application.dataPath + "/save/map.txt";
        string myStr;
        using (FileStream fsRead = new FileStream(@filePath, FileMode.Open))
        {
            int fsLen = (int)fsRead.Length;
            byte[] heByte = new byte[fsLen];
            int r = fsRead.Read(heByte, 0, heByte.Length);
            myStr = System.Text.Encoding.UTF8.GetString(heByte);     
        
        if (myStr == null)
        {
            Debug.Log("根据路径未找到对应表格数据");
            return default(gamedata_Map);
        }
        else
        {
            gamedata_Map  obj = JsonMapper.ToObject<gamedata_Map>(myStr);
            return obj;
        }
        }
    }
    void InitData()
    {
        for (int i = 0; i <levelH; i++)
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
        _seedX = UnityEngine.Random.value * 100f;
        _seedZ = UnityEngine.Random.value * 100f;

        //初始化地图信息，即每个单位对应的地面类型
        TileType = new string[levelH * levelW];
        int check = 0;
        int city_c = 0;
        int village_c = 0;
        int mine_c = 0;
        int stone_c = 0;
        int dikuai=100;
        gamedata_Map mapdata = new gamedata_Map();
        mapdata.map = new Dictionary<string, Mapunit>();
        float height_y;

        for (int i = 0; i < levelH; i++)
        {
            for (int j = 0; j < levelW; j++)
            {

                float xSample = (i + _seedX) / _relief;
                float zSample = (j + _seedZ) / _relief;
                float noise = Mathf.PerlinNoise(xSample, zSample);
                height_y = _maxHeight * noise;
                if(height_y > _maxHeight * 0.89f)
                { dikuai = 205; }
                else if (height_y > _maxHeight * 0.85f)
                { dikuai = 204; }
                else if (height_y > _maxHeight * 0.80f)
                { dikuai = 203; }
                else if (height_y > _maxHeight * 0.74f)
                { dikuai = 202; }
                else if (height_y > _maxHeight * 0.65f)
                { dikuai = 101; }
                else if (height_y > _maxHeight * 0.20f)
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

                }
                else if (height_y <= _maxHeight * 0.2f)
                { dikuai = 101; }
                TileType[i * levelW + j] = dikuai.ToString();
                mapdata.map.Add(Convert.ToString(i * levelW + j) , setunit(dikuai, i,j));
                //Debug.Log("dikuai:" + dikuai);
            }
        }
        Savemap(mapdata);
    }
    Mapunit setunit(int dikuai,int posx, int posy)
    {
        Mapunit unit = new Mapunit();
        unit.mapid = posx * levelW + posy;
        unit.mapdetail= dikuai;
        unit.pos =new int[2] {posx, posy};
        return unit;

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
            //Debug.Log(info.Key + " " + info.Value.pic);
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
            if (info.Value.type != 2 & info.Value.type != 10) {
                
                maxweight = maxweight + info.Value.weight;
                //Debug.Log(info.Key + " " + info.Value.pic);
                weightlist.Add(maxweight, info.Value.id);
            
            }
        }
        int weight= UnityEngine.Random.Range(1, maxweight+1);
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
