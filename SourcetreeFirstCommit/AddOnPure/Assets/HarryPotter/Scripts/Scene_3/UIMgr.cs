using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour {

    [SerializeField]
    protected RectTransform floorScan, setPosition, enterRoom, exploreRoom, speech, mano;
    [SerializeField]
    protected Image playBtn;

    private void Start()
    {
        //FadeEffect(playBtn, 0.5f, 1.5f, 1.5f);
        floorScan.DOAnchorPos(Vector2.zero,0.25f);
    }

    public void FloorScanBtn()
    {
        setPosition.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        floorScan.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void SetPositionBtn()
    {
        floorScan.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        setPosition.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseSetPositionBtn()
    {
        floorScan.DOAnchorPos(new Vector2(0, 0), 0.25f);
        setPosition.DOAnchorPos(new Vector2(1500, 0), 0.25f);
    }
    public void EnterRoomBtn()
    {
        setPosition.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        enterRoom.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseEnterRoomBtn()
    {
        setPosition.DOAnchorPos(new Vector2(0, 0), 0.25f);
        enterRoom.DOAnchorPos(new Vector2(1500, 0), 0.25f);
    }

    public void ExPloreRoomBtn()
    {
        enterRoom.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        exploreRoom.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseExploreRoomBtn()
    {
        enterRoom.DOAnchorPos(new Vector2(0, 0), 0.25f);
        exploreRoom.DOAnchorPos(new Vector2(1500, 0), 0.25f);
    }

    public void SpeechBtn()
    {
        exploreRoom.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        speech.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseSpeechBtn()
    {
        exploreRoom.DOAnchorPos(new Vector2(0, 0), 0.25f);
        speech.DOAnchorPos(new Vector2(1500, 0), 0.25f);
    }

    public void ManoBtn()
    {
        speech.DOAnchorPos(new Vector2(-1500, 0), 0.25f);
        mano.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseManoBtn()
    {
        speech.DOAnchorPos(new Vector2(0, 0), 0.25f);
        mano.DOAnchorPos(new Vector2(1500, 0), 0.25f);
    }















    //    void FadeEffect(Image _image, float fadeTo, float fadeDuration, float delay)
    //    {
    //        _image.DOFade(fadeTo, fadeDuration);
    //        _image.DOFade(1, fadeDuration).SetDelay(delay).OnComplete(() => FadeEffect(_image, fadeTo, fadeDuration, delay));
    //    }

    //    void MoveUI(RectTransform _traansform, Vector2 position, float moveTime, float delayTime, Ease ease)
    //    {
    //        _traansform.DOAnchorPos(position, moveTime).SetDelay(delayTime).SetEase(ease);
    //    }
}
