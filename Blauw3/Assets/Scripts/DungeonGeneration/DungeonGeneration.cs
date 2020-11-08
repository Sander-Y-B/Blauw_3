using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{


    void Start()
    {
        for (int i = 0; i < 1; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/* instantiate room
 * check if "doors" already have rooms
 * randomly spawn room at "door" for every room
 * repeat process for spawned room
 * when max room is reached, closes al non connected "doors"
 */