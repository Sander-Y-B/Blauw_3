using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minimap : MonoBehaviour
{
    public SpawnEnemies roomscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roomscript != null)
        {
            if (roomscript.roomCleared == true)
            {
                this.gameObject.GetComponent<Image>().color = Color.green;
                this.enabled = false;
            }
        }
       
    }
}
