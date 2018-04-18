using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class GeneBrian : MonoBehaviour {

    public int DNALength = 1;
    public float timeAlive;
    public GeneDNA dna;

    private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        // Initialize DNA
        // 0 forward
        // 1 back
        // 2 left
        // 3 right
        // 
    }
}
