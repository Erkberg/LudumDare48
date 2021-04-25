using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerInteraction playerInteraction;
    public PlayerAnimation playerAnimation;

    public GameObject enemyObject;

    public void ChangeToEnemy()
    {
        playerMovement.transform.rotation = Quaternion.identity;
        playerAnimation.animator.gameObject.SetActive(false);
        enemyObject.SetActive(true);
    }
}
