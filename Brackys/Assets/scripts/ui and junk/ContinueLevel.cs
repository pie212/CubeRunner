using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLevel : MonoBehaviour
{
    public bool ContainsMuisc;
    private PLayerMovement player;
    private GameManager Gamemanager;
    // Start is called before the first frame update
    void Start(){
        player = FindObjectOfType<PLayerMovement>();
        Gamemanager = FindObjectOfType<GameManager>();
    }
    public void LevelContinue(){
        
        Gamemanager.pauseLevelUI.SetActive(false);
        Gamemanager.gameIsPaused = false;
        if (ContainsMuisc == true){
        FindObjectOfType<AudioSource>().Play();
        }
        Debug.Log(player.retainedSpeed);
        player.rb.constraints = RigidbodyConstraints.None;
        player.rb.velocity = player.retainedSpeed;
        player.jumpCON.Enable();      //allows input again
        player.move.Enable();
        player.powerup.Enable();
        player.menu.Enable();
        player.pitch.Enable();
        player.yaw.Enable();
        
    }

}
