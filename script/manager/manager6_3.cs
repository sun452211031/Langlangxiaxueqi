﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager6_3 : MonoBehaviour
{
    private bool isEditor;
    public AudioClip[] dubs;
    public GameObject[] models;
    public GameObject[] buttons;
    private AudioSource thisAudioSource;
    private string doFunctionName = "";
    private AudioSource buttonSoundeffect;
    private float timeInvoke;
    private bool canTimeInvoke = false;
    private float thisTime;
    public Renderer BackgroundPlane;
    void Awake()
    {
        buttonSoundeffect = GameObject.Find("/AudioManager/button").GetComponent<AudioSource>();
        if (Application.isEditor)
        {
            isEditor = true;
        }
        else
        {
            isEditor = false;
        }
        thisAudioSource = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (canTimeInvoke)
        {
            timeInvoke += Time.deltaTime;
        }
        if (isEditor == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit thisRaycastHit;
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out thisRaycastHit))
                {
                    if (thisRaycastHit.collider.gameObject.tag == "button3")
                    {
                        buttonSoundeffect.Play();
                        var HitObjName = thisRaycastHit.collider.gameObject.name;
                        this.SendMessage(HitObjName, gameObject, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
        else
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit thisRaycastHit;
                    if (Physics.Raycast(ray, out thisRaycastHit))
                    {
                        if (thisRaycastHit.collider.gameObject.tag == "button3")
                        {
                            buttonSoundeffect.Play();
                            var HitObjName = thisRaycastHit.collider.gameObject.name;
                            this.SendMessage(HitObjName, gameObject, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
    }
    private void closeAll()
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    void OnBecameVisible()
    {
        //#region 雾效设置
        //RenderSettings.fogDensity = 0;
        //#endregion
        //#region 环境设置
        //BackgroundPlane.material.shader = Shader.Find("Diffuse");
        //BackgroundPlane.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
        //#endregion
        if (imageTargetManeger.nowImageTarget != 3)
        {
            closeAll();
            doFunctionName = "";
            imageTargetManeger.nowImageTarget = 3;
        }
        canTimeInvoke = true;
        if (doFunctionName != "")
        {
            var thisfloat = thisTime - timeInvoke;
            if (thisfloat > 0)
            {
                Invoke(doFunctionName, thisfloat);
            }
        }
        else
        {
            step1();
        }
        Animation[] animationComponents = GetComponentsInChildren<Animation>(true);
        foreach (Animation component in animationComponents)
        {
            component.enabled = true;
        }
        AudioSource[] audioSourceComponents = GetComponentsInChildren<AudioSource>(true);
        foreach (AudioSource component in audioSourceComponents)
        {
            component.pitch = 1;
        }
    }
    void OnBecameInvisible()
    {
        //#region 雾效设置
        //RenderSettings.fogDensity = 0;
        //#endregion
        //#region 环境设置
        //BackgroundPlane.material.shader = Shader.Find("Diffuse");
        //BackgroundPlane.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
        //#endregion
        canTimeInvoke = false;
        CancelInvoke();
        Animation[] animationComponents = GetComponentsInChildren<Animation>(true);
        foreach (Animation component in animationComponents)
        {
            component.enabled = false;
        }
        AudioSource[] audioSourceComponents = GetComponentsInChildren<AudioSource>(true);
        foreach (AudioSource component in audioSourceComponents)
        {
            component.pitch = 0;
        }
    }
    private void step1()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 5.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(true);
        models[0].animation.Play("Take 001");
        thisAudioSource.clip = dubs[0];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step2_2";
        thisTime = 6;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step2_2()
    {
        #region 前置
        doFunctionName = "step3";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[0].SetActive(true);
    }
    private void step3()
    {
        #region 前置
        doFunctionName = "step3_2";
        thisTime = 6;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[0].SetActive(false);
        models[0].SetActive(false);
        models[1].SetActive(true);
        models[1].animation.Play("Take 001");
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step3_2()
    {
        #region 前置
        doFunctionName = "step4";
        thisTime = 4;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[1].SetActive(false);
        models[2].SetActive(true);
        models[2].animation.Play("Take 001");
        Invoke(doFunctionName, thisTime);
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step5";
        thisTime = 8;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step5()
    {
        #region 前置
        doFunctionName = "step5_2";
        thisTime = 4.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(false);
        models[3].SetActive(true);
        models[3].animation.Play("Take 001");
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step5_2()
    {
        #region 前置
        doFunctionName = "step6";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(true);
    }
    private void step6()
    {
        #region 前置
        doFunctionName = "step7";
        thisTime = 8.6f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(false);
        models[3].animation.Play("Take 002");
        thisAudioSource.clip = dubs[5];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step7()
    {
        #region 前置
        doFunctionName = "step8";
        thisTime = 2.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[6];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step8()
    {
        #region 前置
        doFunctionName = "step8_2";
        thisTime = 2.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[3].SetActive(false);
        models[4].SetActive(true);
        models[4].animation.Play("Take 001");
        thisAudioSource.clip = dubs[7];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step8_2()
    {
        #region 前置
        doFunctionName = "step9";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[2].SetActive(true);
    }
    private void step9()
    {
        #region 前置
        doFunctionName = "step10";
        thisTime = 13;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[2].SetActive(false);
        models[4].animation.Play("Take 002");
        thisAudioSource.clip = dubs[8];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step10()
    {
        #region 前置
        doFunctionName = "step11";
        thisTime = 5.5f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[9];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step11()
    {
        #region 前置
        doFunctionName = "step11_2";
        thisTime = 2.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[4].SetActive(false);
        models[5].SetActive(true);
        models[5].animation.Play("Take 001");
        thisAudioSource.clip = dubs[10];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step11_2()
    {
        #region 前置
        doFunctionName = "step12";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[3].SetActive(true);
    }
    private void step12()
    {
        #region 前置
        doFunctionName = "step13";
        thisTime = 13.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[3].SetActive(false);
        models[5].animation.Play("Take 002");
        thisAudioSource.clip = dubs[11];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step13()
    {
        #region 前置
        doFunctionName = "step13_2";
        thisTime = 4.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[12];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step13_2()
    {
        #region 前置
        doFunctionName = "chongxinkaishi";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[4].SetActive(true);
    }
    private void chongxinkaishi()
    {
        closeAll();
        step1();
    }
}
