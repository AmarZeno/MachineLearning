using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MLPopulationManager : MonoBehaviour {

    public GameObject AgentPrefab;
    public int PopulationSize = 10;

    List<GameObject> Population = new List<GameObject>();
    public static float elapsed = 0;

    int trialTime = 10;
    int generation = 1;

    GUIStyle guiStyle = new GUIStyle();
    void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiStyle);
        GUI.Label(new Rect(10, 65, 100, 20), "Trial Time: " + (int)elapsed, guiStyle);
    }

	// Use this for initialization
	void Start () {
		for(int i = 0; i < PopulationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
            GameObject AgentObject = Instantiate(AgentPrefab, pos, Quaternion.identity);
            AgentObject.GetComponent<MLDNA>().R = Random.Range(0.0f, 1.0f);
            AgentObject.GetComponent<MLDNA>().G = Random.Range(0.0f, 1.0f);
            AgentObject.GetComponent<MLDNA>().B = Random.Range(0.0f, 1.0f);
            AgentObject.GetComponent<MLDNA>().S = Random.Range(0.1f, 0.3f);
            Population.Add(AgentObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if(elapsed > trialTime)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
	}

    void BreedNewPopulation()
    {
        List<GameObject> NewPopulation = new List<GameObject>();
        List<GameObject> SortedList = Population.OrderByDescending(o => o.GetComponent<MLDNA>().TimeToDie).ToList();

        Population.Clear();

        // Breed upper half of sorted list
        for(int i = (int)(SortedList.Count/ 2.0f) - 1; i < SortedList.Count - 1; i++)
        {
            Population.Add(Breed(SortedList[i], SortedList[i + 1]));
            Population.Add(Breed(SortedList[i + 1], SortedList[i]));
        }

        for(int i = 0; i < SortedList.Count; i++)
        {
            Destroy(SortedList[i]);
        }

        generation++;
    }

    GameObject Breed(GameObject ParentA, GameObject ParentB)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
        GameObject offspring = Instantiate(AgentPrefab, pos, Quaternion.identity);

        MLDNA DNA1 = ParentA.GetComponent<MLDNA>();
        MLDNA DNA2 = ParentB.GetComponent<MLDNA>();

        // God of the swapping system for genetic dna
        //Add Mutation
        if (Random.Range(0, 1000) > 5)
        {
            offspring.GetComponent<MLDNA>().R = Random.Range(0, 10) < 5 ? DNA1.R : DNA2.R;
            offspring.GetComponent<MLDNA>().G = Random.Range(0, 10) < 5 ? DNA1.G : DNA2.G;
            offspring.GetComponent<MLDNA>().B = Random.Range(0, 10) < 5 ? DNA1.B : DNA2.B;
            offspring.GetComponent<MLDNA>().S = Random.Range(0, 10) < 5 ? DNA1.S : DNA2.S;
        }
        else
        {
            offspring.GetComponent<MLDNA>().R = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<MLDNA>().G = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<MLDNA>().B = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<MLDNA>().S = Random.Range(0.1f, 0.3f);
        }
        return offspring;
    }
}
