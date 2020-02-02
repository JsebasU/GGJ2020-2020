using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public PoolObj pool;
    GameVariables.Desatres desatres = GameVariables.Desatres.Incendios;
    float timer;
    float chaosEvent;
    private bool isActive;
    private GameController _gameController;
    [SerializeField] Transform center;

    private void Start()
    {
    }

    public void SetGameController(GameController controller)
    {
        this._gameController = controller;
    }
    
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    void StartSpawn()
    {
        if (this.isActive)
        {
            this.isActive = true;
            chaosEvent = Random.Range(GameVariables.minTimeEvent, GameVariables.maxTimeEvent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActive)
        {
            timer += Time.deltaTime;
            if (timer >= chaosEvent)
            {
                chaosEvent = Random.Range(GameVariables.minTimeEvent, GameVariables.maxTimeEvent);
                desatres = (GameVariables.Desatres) Random.Range(0,
                    GameVariables.Desatres.GetNames(typeof(GameVariables.Desatres)).Length - 1);
                Debug.Log(desatres);
                cases();
                timer = 0;
            }
        }
    }

    void cases()
    {
        switch (desatres)
        {
            case GameVariables.Desatres.Meteorito:
            {

                    GameObject met = pool.GetObject(GameVariables.METEORITO_PREFAB);
                    met.SetActive(true);
                    met.transform.SetParent(center);
                    met.transform.localPosition = new Vector3(0, 0, 10);
                    center.rotation = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
                    met.transform.SetParent(null);
                    met.SetActive(true);
                    break;
            }
            case GameVariables.Desatres.Incendios:
            {
                Debug.Log("Incendio");

                    mirarPlaneta(GameVariables.INCENDIO_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Pandemia:
            {
                Debug.Log("Pandemia");

                    mirarPlaneta(GameVariables.PANDEMIA_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Volcan:
            {
                Debug.Log("Volcan");

                    mirarPlaneta(GameVariables.VOLCAN_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Radiacion:
            {
                Debug.Log("Radiacion");

                    mirarPlaneta(GameVariables.RADIACION_PREFAB);
                    break;
            }
        }
    }
    
    void mirarPlaneta(string name)
    {

        GameObject met = pool.GetObject(name);
        met.transform.SetParent(center);
        met.transform.localPosition = new Vector3(0, 0, 1);
        center.rotation = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        met.transform.SetParent(null);
        met.transform.right = -Vector3.zero;
        met.SetActive(true);
    }
}
