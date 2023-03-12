using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    
    public enum GameState
    {
        Invalide = -1,
        GameStart,
        GamePlaying,
        GameOver
    }

    public GameState GameStates = GameState.Invalide;

    public CharacterParameterBase Player;

    public GameObject CheckPoint;
    
    public GameClaerPoint ClearPoint;

    // Update is called once per frame
    private void Update()
    {
        switch (GameStates)
        {
            case GameState.Invalide:
                GameStates = GameState.GameStart;
                break;
            
            case GameState.GameStart:
                GameStates = GameState.GamePlaying;
                break;

            case GameState.GamePlaying:
                if (!Player.gameObject.activeSelf)
                {
                    Player.transform.position = CheckPoint.transform.position;
                    Player.Revival();
                    Player.gameObject.SetActive(true);
                }
                if (ClearPoint.GameClear)
                {
                    GameStates = GameState.GameOver;
                }
                break;
            case GameState.GameOver:
                Debug.Log("Clear");
                break;
        }
    }
}
