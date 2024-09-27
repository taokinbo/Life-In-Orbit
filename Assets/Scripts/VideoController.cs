using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] UIController uiCon;
    private bool isPrepared1Frame = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer == null) return;
        if (isPrepared1Frame && videoPlayer.isPrepared && !videoPlayer.isPlaying) {
            uiCon.ChangeSceneToPlayersQuarters();
        }
        else {
            if (!isPrepared1Frame && videoPlayer.isPrepared) isPrepared1Frame = true;
        }
    }
}
