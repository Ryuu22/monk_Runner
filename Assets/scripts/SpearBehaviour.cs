using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : MonoBehaviour {

    enum spearStates { active, activating, closing, closed}
    spearStates sS;

    public float counter;
    public float maxTime;

    public float value;
	
	// Update is called once per frame
	void Update ()
    {
        switch (sS)
        {
            case spearStates.active:
                activeUpdate();
                break;
            case spearStates.activating:
                activatingUpdate();
                break;
            case spearStates.closing:
                closingUpdate();
                break;
            case spearStates.closed:
                closeUpdate();
                break;
            default:
                break;
        }
        this.transform.localPosition = new Vector2(this.transform.position.x, value);
    
    }
    void activeUpdate()
    {
        if(counter < maxTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            sS = spearStates.closing;
            Debug.Log(sS);
        }
    }
    void activatingUpdate()
    {
        if (counter < maxTime)
        {
            counter += Time.deltaTime;
            value = Easing.BounceEaseOut(counter, -2, 2, maxTime);
        }
        else
        {
            counter = 0;
            sS = spearStates.active;
            Debug.Log(sS);
        }
    }
    void closingUpdate()
    {
        if (counter < maxTime)
        {
            counter += Time.deltaTime;
            value = Easing.BounceEaseIn(counter, 0, -2, maxTime);
        }
        else
        {
            counter = 0;
            sS = spearStates.closed;
            Debug.Log(sS);
        }
    }
    void closeUpdate()
    {
        if (counter < maxTime)
        {
            counter += Time.deltaTime;


        }
        else
        {
            counter = 0;
            sS = spearStates.activating;
            Debug.Log(sS);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(sS == spearStates.active || sS == spearStates.activating)
        {
             Player player = collision.GetComponent<Player>();
             player.Die();
        }

    }
}

