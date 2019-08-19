using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColiisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip Explosion;
    [SerializeField] GameObject deathfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Damage");
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine("Damage");
    }
    IEnumerator Damage()
    {

        //now send damage every few seconds
        print("Damage Taken");
        SendMessage("DamageTaken", 10);
        yield return new WaitForSeconds(2);
    }

    private void Sceneloader()
    {
        //subtract health from maxhealth
        SceneManager.LoadScene(1);
        // make coroutine start ontriggerenter
        // when ontriggerexit happens. stop coroutine
    }
}
