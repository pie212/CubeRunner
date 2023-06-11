using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLevel : MonoBehaviour
{
    public PLayerMovement player;
    public GameManager Gamemanager;
    // Start is called before the first frame update
    
    public void LevelContinue(){
        
        Gamemanager.pauseLevelUI.SetActive(false);
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
