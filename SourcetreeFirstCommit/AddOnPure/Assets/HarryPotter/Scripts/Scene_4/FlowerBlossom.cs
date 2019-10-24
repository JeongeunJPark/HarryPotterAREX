using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBlossom : MonoBehaviour
{
    public int _uvTieX = 8;
    public int _uvTieY = 8;
    public int _fps = 10;

    public float mWaitBeforeStart = 2.0f;
    public int mLoopStartFrame = 24;

    private float mStartWait;

    private float iX = 0;
    private float iY = 1;

    private int mMaxFrames;
    private int mFrameCntr;
    private Vector2 _size;
    private Renderer _myRenderer;
    private int mLastCntr = -1;


    void Start()
    {
        //꽃 피기 전 대기 시간 == 사용자 설정 대기시간
        mStartWait = mWaitBeforeStart;

        _size = new Vector2(1.0f / _uvTieX, 1.0f / _uvTieY);

        //렌더러 얻어오기
        _myRenderer = GetComponent<Renderer>();
        if (_myRenderer == null)
            enabled = false;

        _myRenderer.material.SetTextureScale("_MainTex", _size);

        //0에서 1까지 점차적으로 꽃 피워내기
        Vector2 offset = new Vector2(0.0f, 1.0f - _size.y);
        _myRenderer.material.SetTextureOffset("_MainTex", offset);

        //최대프레임 = 8프레임 * 8프레임
        mMaxFrames = _uvTieX * _uvTieY;

        //루프 프레임 타임 >= 최대 프레임보다 크다면
        if (mLoopStartFrame >= mMaxFrames)
        {
            Debug.Log("mLoopStartFrame error!!");
            mLoopStartFrame = 0;
        }

        //프레임 카운트 == 0;
        mFrameCntr = 0;
    }

    void Update()
    {
        // 설정 상 시작하는 시간이 0보다 크다면
        if (mStartWait > 0.0f)
        {
            //지속적으로 대기시간을 줄여 0으로 만듦
            mStartWait -= Time.deltaTime;
            if (mStartWait < 0.0f)
                mStartWait = 0.0f;
            else
                return;
        }

    }


    public void Blossom()
    {
        int cntr = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);
        if (cntr != mLastCntr)
        {
            iX = mFrameCntr % _uvTieX;
            iY = ((mFrameCntr / _uvTieX) + 1) % _uvTieY;

            Vector2 offset = new Vector2(iX * _size.x, 1.0f - (_size.y * iY));
            _myRenderer.material.SetTextureOffset("_MainTex", offset);

            //프레임을 점차 키워간다.
            //프레임을 ++ 하면서 꽃 에셋이 점차 피어나는 것처럼 보인다.
            mFrameCntr++;

            if (mFrameCntr == mMaxFrames)
            {
                iX = mLoopStartFrame % _uvTieX;
                iY = ((mLoopStartFrame / _uvTieX) + 1) % _uvTieY;
                mFrameCntr = mLoopStartFrame;
            }

            mLastCntr = cntr;
        }
    }

    public void Seed()
    {
        int cntr = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);
        if (cntr != mLastCntr)
        {
            iX = mFrameCntr % _uvTieX;
            iY = ((mFrameCntr / _uvTieX) + 1) % _uvTieY;

            Vector2 offset = new Vector2(iX * _size.x, 1.0f - (_size.y * iY));
            _myRenderer.material.SetTextureOffset("_MainTex", offset);

            //프레임을 점차 줄인다.
            //이 과정을 통해 꽃 이미지의 렌더링이 -- 되어 꽃이 씨앗 상태로 돌아가는 것 처럼 보인다.
            mFrameCntr--;

            if (mFrameCntr == mMaxFrames)
            {
                iX = mLoopStartFrame % _uvTieX;
                iY = ((mLoopStartFrame / _uvTieX) + 1) % _uvTieY;
                mFrameCntr = mLoopStartFrame;
            }

            mLastCntr = cntr;
        }
    }
}
