using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page_gamehome : MonoBehaviour
{
    public GameObject page_game;
    public GameObject window_roleinfo;
    // Start is called before the first frame update
    void Start()
    {
        page_action.Setactive(1, page_game);
        page_action.Setactive(0, window_roleinfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
