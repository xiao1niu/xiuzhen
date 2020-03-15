using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapcreater : MonoBehaviour {
    public GameObject floor;
    public Sprite[] floorSp;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            for (int j = 0; j < 10; j++)
            {

                GameObject floor0 = (GameObject)Instantiate(floor, new Vector3(0.48f * i, 0.48f * j, 0), Quaternion.identity);

                floor.GetComponent<SpriteRenderer>().sprite = floorSp[Random.Range(0, floorSp.Length - 1)];

            }
        }
    }
	// Update is called once per frSame
	void Update () {
		
	}
}
