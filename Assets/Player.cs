using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 20f;
    [SerializeField] float RangeX = 12f;
    [SerializeField] float RangeY = 10f;
    [SerializeField] float pitchFactor = -1f;
    [SerializeField] float ControlPitchFactor = -1;
    [SerializeField] float ControlYawFactor = -1f;
    [SerializeField] float YawFactor = -1;
    float VerticalMovementY;
    float HorizontalMovementX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
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
        VerticalMovementY = CrossPlatformInputManager.GetAxis("Vertical");
        float offsetY = VerticalMovementY * Time.deltaTime * Speed*5;
        float ChangeinPosY = transform.localPosition.y + offsetY;
        HorizontalMovementX = CrossPlatformInputManager.GetAxis("Horizontal");
        float offsetX = Time.deltaTime * HorizontalMovementX * Speed*10;
        float ChangeinPosX = transform.localPosition.x + offsetX;
        transform.localPosition = new Vector3(Mathf.Clamp(ChangeinPosX,-RangeX,RangeX), Mathf.Clamp(ChangeinPosY,-RangeY,RangeY), transform.localPosition.z);
    }

}
