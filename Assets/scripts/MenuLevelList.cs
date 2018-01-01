using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevelList : MonoBehaviour {


    public List<GameObject> sprites;
    public int spriteIndex;
    public int maxLevels;

    public float freq;
    Vector3 currentpos;
	
	// Update is called once per frame
	void Update ()
    {
        currentpos = Vector2.Lerp(this.transform.position, new Vector2(spriteIndex * -5, 0), freq);

        this.transform.position = currentpos;
	}

    public void MoveRight()
    {
        if (spriteIndex < maxLevels)
        {
            spriteIndex++;

            //Every frame checks if it's selected
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].GetComponent<LevelFrameBehaviour>().IsSelected(spriteIndex);
            }

        }
    }
    public void MoveLeft()
    {
        
        if(spriteIndex > 0)
        {
            spriteIndex--;

            //Every frame checks if it's selected

            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].GetComponent<LevelFrameBehaviour>().IsSelected(spriteIndex);
            }
        }
    }
}
