using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 20f;
    [SerializeField] float RangeX = 12f;
    [SerializeField] float RangeY = 10f;
    [SerializeField] float pitchFactor = -1f;
    [SerializeField] float ControlPitchFactor = -1;
    [SerializeField] float ControlYawFactor = -1f;
    [SerializeField] float YawFactor = -1;
    [SerializeField] int MaxHealth = 100;
    [SerializeField] int CurrentHealth = 100;
    float VerticalMovementY;
    float HorizontalMovementX;
    Collider colliderPlayer;
    [SerializeField] GameObject deathfx;
    enum PlayerState{dead,alive}
    PlayerState Ship = PlayerState.alive;
    // Start is called before the first frame update
    void Start()
    {
        colliderPlayer = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ship == PlayerState.alive)
        {
            ProcessMovement();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitchposition=transform.localPosition.y*pitchFactor;
        float pitchDueTocontrol = VerticalMovementY * ControlPitchFactor;
        float totalpitch = pitchDueTocontrol + pitchposition;
        float YawDueToPosition = transform.localPosition.x * YawFactor;
        float YawDueToControl = HorizontalMovementX * ControlYawFactor;
        float TotalYaw = YawDueToControl + YawDueToPosition;
        float roll=0;
        transform.localRotation = Quaternion.Euler(totalpitch,TotalYaw,roll);
        //if we move up 10 units we pitch up -10
    }

    private void ProcessMovement()
    {
        // offset*deltatime*speed applied to position for new position, with clamped value
        VerticalMovementY = CrossPlatformInputManager.GetAxis("Vertical");
        float offsetY = VerticalMovementY * Time.deltaTime * Speed*5;
        float ChangeinPosY = transform.localPosition.y + offsetY;
        HorizontalMovementX = CrossPlatformInputManager.GetAxis("Horizontal");
        float offsetX = Time.deltaTime * HorizontalMovementX * Speed*10;
        float ChangeinPosX = transform.localPosition.x + offsetX;
        transform.localPosition = new Vector3(Mathf.Clamp(ChangeinPosX,-RangeX,RangeX), Mathf.Clamp(ChangeinPosY,-RangeY,RangeY), transform.localPosition.z);
    }
    private void DamageTaken(int Damage)
    {

        CurrentHealth = CurrentHealth - Damage;
        //disable collider for 2 seconds
        Invulnerabilityfor2Seconds();
        //enable collider afterwords
        if (CurrentHealth == 0)
        {
            DeathThenReloadStage();
        }
    }

    private void DeathThenReloadStage()
    {
        Ship = PlayerState.dead;
        print("Out of Health");

        deathfx.SetActive(true);
        Invoke("Level1", 1f);
    }

    private void Level1()
    {
        SceneManager.LoadScene(1);
    }

    void Invulnerabilityfor2Seconds()
    {
        colliderPlayer.enabled=false;
        StartCoroutine("Invulnerability");
        
    }
    IEnumerator Invulnerability()
    {

        yield return new WaitForSecondsRealtime(2);
        colliderPlayer.enabled = true;
    }
}
