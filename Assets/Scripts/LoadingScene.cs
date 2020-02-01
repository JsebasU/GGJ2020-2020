using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider slider;
    public TextMeshProUGUI progressTx;

    public void startChange(int value) {

#if UNITY_WEBGL || UNITY_WINDOWS
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
#endif
        StartCoroutine(LoadAsinc(value));
    }

    IEnumerator LoadAsinc(int sIndex) {

        AsyncOperation asyncOP = SceneManager.LoadSceneAsync(sIndex);
        loadingPanel.SetActive(true);

        while (!asyncOP.isDone) {
            float progress = Mathf.Clamp01(asyncOP.progress / 0.9f);
            slider.value = (progress * 100f);
            progressTx.text = (int)(progress * 100f) + "%";

            yield return null;
        }
    }

}
