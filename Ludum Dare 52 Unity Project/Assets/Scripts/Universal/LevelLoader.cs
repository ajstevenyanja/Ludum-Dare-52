using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public TMP_Text percentageText;

    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadLevel(int sceneIndex)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            // in unity actual loading operation takes place from 0 to 0.9, 0.9 to 1 is where activation takes place
            // but we need loading bar to go from 0 to 1 so we normalise it to .9f
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
            percentageText.text = Mathf.Floor(progress * 100f) + "%";

            // to break for 1 frame before continuing
            yield return null;
        }
    }
}

