using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLDNA : MonoBehaviour {

    // Gene for color
    public float R, G, B;
    public float TimeToDie = 0;
    public float S;

    bool dead = false;
    SpriteRenderer AgentSpriteRenderer;
    Collider2D AgentCollider;

	// Use this for initialization
	void Start () {
        AgentSpriteRenderer = GetComponent<SpriteRenderer>();
        AgentCollider = GetComponent<Collider2D>();
        AgentSpriteRenderer.color = new Color(R, G, B);
        this.transform.localScale = new Vector3(S, S, S);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        dead = true;
        TimeToDie = MLPopulationManager.elapsed;
        Debug.Log("Dead at : " + TimeToDie);
        AgentSpriteRenderer.enabled = false;
        AgentCollider.enabled = false;
    }
}
