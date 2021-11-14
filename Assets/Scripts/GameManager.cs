using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Config")]
    public float speed;

    public float yMaxLimit;
    public float yMinLimit;
    public float xMaxLimit;
    public float xMinLimit;

    [Header("Objects Config")]
    public float objectsSpeed;
    public float positionXToDestroy;
    public float bridgeWidth;
    public GameObject bridgePrefab;

    [Header("Barril Config")]
    public int topOrderInLayer;
    public int bottomOrderInLayer;
    public float topPositionY;
    public float bottomPositionY;
    public float timeToSpawn;
    public GameObject barrilPrefab;

    [Header("Globals")]
    public Text txtScore;
    public int score = 0;

    void Start()
    {
        StartCoroutine("SpawnBarril");
    }

    void Update()
    {

    }

    IEnumerator SpawnBarril()
    {
        yield return new WaitForSeconds(timeToSpawn);
        float positionY;
        int order;

        if (Random.Range(0, 100) < 50)
        {
            positionY = topPositionY;
            order = topOrderInLayer;
        }
        else
        {
            positionY = bottomPositionY;
            order = bottomOrderInLayer;
        }

        GameObject barrilInstance = Instantiate(barrilPrefab);

        barrilInstance.transform.position = new Vector3(barrilInstance.transform.position.x, positionY, 0);
        barrilInstance.GetComponent<SpriteRenderer>().sortingOrder = order;

        StartCoroutine("SpawnBarril");
    }

    public void GivePoints(int points)
    {
        score += points;
        txtScore.text = $"Score: {score.ToString()}";
    }

    public void ChangeScene(string target)
    {
        SceneManager.LoadScene(target);
    }
}
