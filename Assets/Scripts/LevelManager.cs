using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class LevelManager : MonoBehaviour
{
    public GameObject EnemyParent;
    public GameObject WinPanel;
    public GameObject DiePanel;
    private PlayerFight _playerFight;

    public LevelManagerSo levelManagerSo;
    
    private bool _panelActive = false;



    void Start()
    {
        _panelActive = false;
       _playerFight = FindObjectOfType<PlayerFight>();
    }

    void FixedUpdate()
    {
        if(EnemyParent == null)
        return;

        if(EnemyParent.transform.childCount == 0)
        {
            if(_panelActive)
            return;
            WinPanel.SetActive(true);
            levelManagerSo.NumberOfLevels++;
            _panelActive = true;
        }
        if(_playerFight.PlayerHp <= 0.5f)
        {
             if(_panelActive)
            return;
            
            DiePanel.SetActive(true);
            _panelActive = true;
        }
    }

     public void StartGame()
    {
        if (levelManagerSo.LevelsSceneNames.Contains("Level" + levelManagerSo.NumberOfLevels.ToString()))
        {
            SceneManager.LoadScene("Level" + levelManagerSo.NumberOfLevels.ToString());
        }
    }
    public void MainMenu()
    {
         SceneManager.LoadScene(levelManagerSo.MainMenu);
    } 
}
