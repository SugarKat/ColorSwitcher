using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void ObjectActivation();
    public event ObjectActivation MoveObjects;

    public static GameManager instance;

    [SerializeField]
    GameObject colorWall;
    [SerializeField]
    GameObject blackLevel;
    [SerializeField]
    GameObject colorLevel;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one game manager!");
            Destroy(this);
            return;
        }
        instance = this;
    }
    void Start()
    {
        blackLevel.SetActive(true);
        colorLevel.SetActive(false);

        PlayerInput.instance.ChangeSpace += ChangeActiveDimension;
    }
    void ChangeActiveDimension()
    {
        blackLevel.SetActive(!blackLevel.activeSelf);
        colorLevel.SetActive(!colorLevel.activeSelf);
    }
    private void OnDestroy()
    {
        PlayerInput.instance.ChangeSpace -= ChangeActiveDimension;
    }
    public void ActivateObj()
    {
        MoveObjects?.Invoke();
    }
    public GameObject CreateObjectInColor(Transform transform,GameObject prefab)
    {
        GameObject obj = GameObject.Instantiate(prefab, transform.position, transform.rotation, colorLevel.transform);
        obj.transform.localScale = transform.localScale;
        return obj;
    }
    public GameObject CreateObjectInBlack(Transform transform,GameObject prefab)
    {
        GameObject obj = GameObject.Instantiate(prefab, transform.position, transform.rotation, blackLevel.transform);
        obj.transform.localScale = transform.localScale;
        return obj;
    }
    public void LoadNextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if(activeScene.buildIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(activeScene.buildIndex + 1);
        }
    }
}
