using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager2_3 : MonoBehaviour
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
    private bool step3bool = true;
    private bool step4bool = true;
    private bool step5bool = true;
    private bool step7bool = true;
    private bool step8bool = true;
    private bool step9bool = true;
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
        doFunctionName = "step1_2";
        thisTime = 8.5f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step3bool = true;
        step4bool = true;
        step5bool = true;
        step7bool = true;
        step8bool = true;
        step9bool = true;
        models[0].SetActive(true);
        models[1].SetActive(true);
        models[1].animation.Play("Take 001");
        thisAudioSource.clip = dubs[0];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step1_2()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[0].SetActive(true);
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step2_2";
        thisTime = 6.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[1].SetActive(false);
        models[2].SetActive(true);
        buttons[0].SetActive(false);
        models[2].animation.Play("Take 001");
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step2_2()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        buttons[3].SetActive(true);
    }

    private void step3()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 5;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(true);
        models[3].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        models[2].animation.Play("Take 002");
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
        step3bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 5;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(true);
        models[3].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        models[2].animation.Play("Take 003");
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
        step4bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step5()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 5;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(false);
        models[3].SetActive(true);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        models[3].animation.Play("Take 001");
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
        step5bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step345close()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(step3bool);
        buttons[2].SetActive(step4bool);
        buttons[3].SetActive(step5bool);
        if (step3bool == false && step4bool == false && step5bool == false)
        {
            step6();
        }
    }
    private void step6()
    {
        #region 前置
        doFunctionName = "step6_2";
        thisTime = 7.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(true);
        models[3].SetActive(false);
        models[2].animation.Play("Take 004");
        thisAudioSource.clip = dubs[5];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step6_2()
    {
        #region 前置
        doFunctionName = "step789close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[4].SetActive(true);
        buttons[5].SetActive(true);
        buttons[6].SetActive(true);
    }

    private void step7()
    {
        #region 前置
        doFunctionName = "step789close";
        thisTime = 7;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(false);
        models[4].SetActive(true);
        models[5].SetActive(false);
        buttons[4].SetActive(false);
        buttons[5].SetActive(false);
        buttons[6].SetActive(false);
        models[4].animation.Play("Take 001");
        thisAudioSource.clip = dubs[6];
        thisAudioSource.Play();
        step7bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step8()
    {
        #region 前置
        doFunctionName = "step789close";
        thisTime = 7.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(false);
        models[4].SetActive(true);
        models[5].SetActive(false);
        buttons[4].SetActive(false);
        buttons[5].SetActive(false);
        buttons[6].SetActive(false);
        models[4].animation.Play("Take 002");
        thisAudioSource.clip = dubs[7];
        thisAudioSource.Play();
        step8bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step9()
    {
        #region 前置
        doFunctionName = "step789close";
        thisTime = 9;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].SetActive(false);
        models[4].SetActive(false);
        models[5].SetActive(true);
        buttons[4].SetActive(false);
        buttons[5].SetActive(false);
        buttons[6].SetActive(false);
        models[5].animation.Play("Take 001");
        thisAudioSource.clip = dubs[8];
        thisAudioSource.Play();
        step9bool = false;
        Invoke(doFunctionName, thisTime);
    }
    private void step789close()
    {
        #region 前置
        doFunctionName = "step345close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[4].SetActive(step7bool);
        buttons[5].SetActive(step8bool);
        buttons[6].SetActive(step9bool);
        if (step7bool == false && step8bool == false && step9bool == false)
        {
            step10();
        }
    }
    private void step10()
    {
        #region 前置
        doFunctionName = "step10_2";
        thisTime = 6;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(true);
        models[1].SetActive(true);
        models[4].SetActive(false);
        models[5].SetActive(false);
        models[1].animation.Play("Take 001");
        thisAudioSource.clip = dubs[9];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step10_2()
    {
        #region 前置
        doFunctionName = "step10_3";
        thisTime = 3.8f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[10];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step10_3()
    {
        #region 前置
        doFunctionName = "chongxinkaishi";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[7].SetActive(true);
    }
    private void chongxinkaishi()
    {
        closeAll();
        step1();
    }
}
