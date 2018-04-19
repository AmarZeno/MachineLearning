﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseBrain : MonoBehaviour {

    public int DNALength = 2;
    public float timeAlive;
    public GeneDNA dna;

    public GameObject eyes;
    bool alive = true;
    bool seeGround = true;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        // Initialize DNA
        // 0 forward
        // 1 left
        // 2 right
        // 

        dna = new GeneDNA(DNALength,3);
        timeAlive = 0;
        alive = true;
    }

    private void Update()
    {
        if (!alive) return;

        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, 10);
        seeGround = false;
        RaycastHit hit;

        if(Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        {
            if(hit.collider.gameObject.tag == "platform")
            {
                seeGround = true;
            }
        }

        timeAlive = SensePopulationManager.elapsed;

        // read DNA
        float turn = 0;
        float move = 0;
        if(seeGround)
        {
            if (dna.GetGene(0) == 0) move = 1;
            else if (dna.GetGene(0) == 1) turn = -90;
            else if (dna.GetGene(0) == 2) turn = 90;
        }
        else
        {
            if (dna.GetGene(1) == 0) move = 1;
            else if (dna.GetGene(1) == 1) turn = -90;
            else if (dna.GetGene(1) == 2) turn = 90;
        }

        this.transform.Translate(0, 0, move * 0.1f);
        this.transform.Rotate(0, turn, 0);
    }
}
