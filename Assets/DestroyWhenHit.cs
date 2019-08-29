using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenHit : MonoBehaviour
{
    [SerializeField] GameObject Deathfx;
    [SerializeField] Transform parent;
    [SerializeField] int scoreperhit = 1;
    // Start is called before the first frame update
    scoreBoard ScoreBoard;
    void Start()
    {
        AddNonTriggerBoxCollider();
        ScoreBoard = FindObjectOfType<scoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddNonTriggerBoxCollider()
    {
        BoxCollider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
        enemyCollider.center = new Vector3(0f, 0f, 0f);
        enemyCollider.size = new Vector3(.2f, .5f, .3f);
    }
    private void OnParticleCollision(GameObject other)
    {
        ScoreBoard.ScorePerHit(scoreperhit);
        GameObject fx = Instantiate(Deathfx, transform.localPosition,Quaternion.identity);
        fx.transform.parent = parent;
        print("particle hit " + gameObject.name);
        Destroy(gameObject);
    }
}
