using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCinemaManager : MonoBehaviour
{
    public Transform CameraTargetPosition;
    public float MoveSpeed = 2.0f; 
    public int IfKillScore = 1;
    private PlayerFight _playerFight;
    

    void Start()
    {
        _playerFight = FindObjectOfType<PlayerFight>();
        
    }

    void Update()
    {
        if(IfKillScore != _playerFight.KillScore)
        return;
        if (CameraTargetPosition != null)
        {
            Vector3 targetPosition = new Vector3(CameraTargetPosition.position.x, CameraTargetPosition.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }
}
