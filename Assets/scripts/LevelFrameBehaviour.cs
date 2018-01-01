using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFrameBehaviour : MonoBehaviour {

    public bool selected;
    public int levelNumber;
    public float freq;

    public Color opacityColor;
    private Color originalcolor;

    public Vector2 defaultScale;
    public Vector2 selectedScale;

    private SpriteRenderer sr;

    private void Start()
    {
        defaultScale = this.transform.localScale;
        sr = this.GetComponent<SpriteRenderer>();
        originalcolor = this.sr.color;
    }

    // Update is called once per frame
    void Update ()
    {
		if(selected)
        {
            this.transform.localScale = Vector2.Lerp(this.transform.localScale, selectedScale, freq);
        }
        else
        {
            this.transform.localScale = Vector2.Lerp(this.transform.localScale, defaultScale, freq);
        }
	}
    public void IsSelected(int spriteIndex)
    {
        if(spriteIndex == levelNumber)
        {
            selected = true;
            sr.color = originalcolor;
            sr.sortingOrder = 1;
        }
        else
        {
            selected = false;

            sr.color = opacityColor;
            sr.sortingOrder = 0;
        }
    }
    
}
