using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Image life1;
    public Image life2;
    public Image life3;
    public int lives = 3;

    int playerScore = 0;

    public void AddScore(){
      playerScore++;
      scoreText.text = playerScore.ToString();
    }

    public void PlayerDied(){
      lives -= 1;
      if(life1.enabled){
        life1.enabled = false;
      }
      else if(life2.enabled){
        life2.enabled = false;
      }
      else{
        life3.enabled = false;
      }
      if(lives == 0){
        gameOverText.enabled = true;
        //This freezes the game
        Time.timeScale = 0;
      }
    }
}
