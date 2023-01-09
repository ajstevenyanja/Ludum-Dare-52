using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject plantFull;
    [SerializeField] GameObject plantExtracted;
    [SerializeField] float holdTime = 3.0f;
    [SerializeField] float sliderLerpSpeed = 10f;

    UpdateScoreText updateScoreText;
    Slider extractSlider;
    float timer = 0;
    bool extracted = false;

    // cached references fetched from plant spawner script
    public void SetupScoreAndSlider(UpdateScoreText _updateScoreText, Slider _extractSlider)
    {
        updateScoreText = _updateScoreText;
        extractSlider = _extractSlider;
    }

    private void Awake()
    {
        plantFull.SetActive(true);
        plantExtracted.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0;
        extractSlider.value = 0;
        extractSlider.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (extracted)
        {
            extractSlider.gameObject.SetActive(false);
            Destroy(this);
        }

        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;

            extractSlider.value = Mathf.Lerp(extractSlider.value, timer / holdTime, Time.deltaTime * sliderLerpSpeed);

            if (timer > holdTime)
            {
                if (!extracted)
                {
                    plantFull.SetActive(false);
                    plantExtracted.SetActive(true);
                    updateScoreText.UpdateScore();
                    extractSlider.value = 1.0f;
                    extracted = true;
                }
            }
        }
        else
        {
            timer = 0;
            extractSlider.value = Mathf.Lerp(extractSlider.value, 0, Time.deltaTime * sliderLerpSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (extracted)
        {
            Destroy(this);
        }

        timer = 0;
        extractSlider.value = 0;
        extractSlider.gameObject.SetActive(false);
    }
}
