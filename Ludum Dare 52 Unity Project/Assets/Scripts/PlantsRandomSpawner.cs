using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsRandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject fullPlantPrefab;
    [SerializeField] GameObject extractedPlantPrefab;
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] UpdateScoreText updateScoreText;
    [SerializeField] Slider extractSlider;

    private void Awake()
    {
        if (!updateScoreText)
        {
            updateScoreText = FindObjectOfType<UpdateScoreText>();
        }
        if (!extractSlider)
        {
            extractSlider = GameObject.FindGameObjectWithTag("Extract Slider").GetComponent<Slider>();
        }

        SpawnRandomPlants();
    }

    private void SpawnRandomPlants()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // roll a dice, 1 & 2 = spawn full plant, 3 = spawn extracted plant, 4 = spawn nothing
            int diceRoll = Random.Range(0, 5);

            if (diceRoll == 3)
            {
                Instantiate(extractedPlantPrefab, spawnPoint.position, transform.rotation, spawnPoint);
            }
            else if (diceRoll != 4)
            {
                GameObject fullPlant = Instantiate(fullPlantPrefab, spawnPoint.position, transform.rotation, spawnPoint);
                fullPlant.GetComponent<Plant>().SetupScoreAndSlider(updateScoreText, extractSlider);
            }
        }
    }
}
