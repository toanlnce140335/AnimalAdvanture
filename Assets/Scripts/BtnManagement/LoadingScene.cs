using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private Image progressBar;
    private float target;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void ChangSceneOnClick(int sceneId)
    {
        target = 0;
        progressBar.fillAmount = 0;
        var scene = SceneManager.LoadSceneAsync(sceneId);
        scene.allowSceneActivation = false;
        loadingScene.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);
        scene.allowSceneActivation = true;
        loadingScene.SetActive(false);
    }

    void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3 * Time.deltaTime);
    }
}
