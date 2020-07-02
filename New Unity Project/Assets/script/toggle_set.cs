using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle_set : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void settoggle()
    {
        GameObject table_toggle= this.gameObject.transform.parent.gameObject;

        foreach (Transform child in table_toggle.transform)
        {
            if(child.name!= this.gameObject.transform.name)
            {
                child.transform.          }
        }


    }
}
