using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

public class GameEnding : MonoBehaviour
{
    public Animator lightAnimator;
    public GameObject light;

    public IEnumerator EndSequence()
    {
        Game.inst.input.SetInputEnabled(false);
        yield return new WaitForSeconds(2f);
        lightAnimator.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        light.SetActive(false);
        
        bool badEnding = Game.inst.progress.irrationality >= 1f;
        if (badEnding)
        {
            Game.inst.refs.playerController.ChangeToEnemy();
            yield return new WaitForSeconds(8f);
        }
        else
        {
            Game.inst.audio.OnMusicLevelChanged(1);
            yield return new WaitForSeconds(5f);
            Game.inst.refs.playerController.playerMovement.inEndSeq = true;
            yield return new WaitUntil(() => Game.inst.refs.playerController.playerMovement.transform.position.y > 33f);
        }

        Game.inst.ui.endingMenuOverlay.SetActive(true);
    }

}
