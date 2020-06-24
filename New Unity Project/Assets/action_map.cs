using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class action_map : MonoBehaviour
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void OnClick()
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();//创建Tile，注意，要使用这种方式
        Sprite tmp = Resources.Load<Sprite>("map/select");
        //Debug.Log(tmp.pixelsPerUnit); 
        //tmp.spriteAtlasTextureScale.
        //tmp.texture.Resize(400,200);
        //Debug.Log(tmp.bounds.size.x);
        tile.sprite = tmp;
        


        //得到由屏幕指向地图的射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(Input.mousePosition);
        //由正确的方向得到屏幕中tile所在的位置
        Vector3Int vector = tilemap.WorldToCell(ray.GetPoint(-ray.origin.z / ray.direction.z));
        //Debug.Log(vector);
        //对该位置进行点击测试
        tilemap.SetTile(vector, tile);
        //tilemap.SetColor(vector, Color.red);
        Debug.Log(vector);
        //if (tilemap.HasTile(vector))
        //{

        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
