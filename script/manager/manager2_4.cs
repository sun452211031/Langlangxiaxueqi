using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager2_4 : MonoBehaviour
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
    private bool step6_1bool = true;
    private bool step6_2bool = true;
    private bool step6_3bool = true;
    private bool step6_4bool = true;
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
                    if (thisRaycastHit.collider.gameObject.tag == "button4")
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
                        if (thisRaycastHit.collider.gameObject.tag == "button4")
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
        if (imageTargetManeger.nowImageTarget != 4)
        {
            closeAll();
            doFunctionName = "";
            imageTargetManeger.nowImageTarget = 4;
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
        doFunctionName = "step2";
        thisTime = 8;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step6_1bool = true;
        step6_2bool = true;
        step6_3bool = true;
        step6_4bool = true;
        models[0].SetActive(true);
        models[1].SetActive(true);
        thisAudioSource.clip = dubs[0];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step4";
        thisTime = 9;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step4_2";
        thisTime = 12.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step4_2()
    {
        #region 前置
        doFunctionName = "step5";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[0].SetActive(true);
    }
    private void step5()
    {
        #region 前置
        doFunctionName = "step5_2";
        thisTime = 8.1f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[0].SetActive(false);
        models[1].SetActive(false);
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step5_2()
    {
        #region 前置
        doFunctionName = "step6close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        buttons[3].SetActive(true);
        buttons[4].SetActive(true);
    }
    private void step6_1()
    {
        #region 前置
        doFunctionName = "step6close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step6_1bool = false;
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(false);
        models[2].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step6_2()
    {
        #region 前置
        doFunctionName = "step6close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step6_2bool = false;
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(false);
        models[3].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step6_3()
    {
        #region 前置
        doFunctionName = "step6close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step6_3bool = false;
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(false);
        models[4].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step6_4()
    {
        #region 前置
        doFunctionName = "step6close";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        step6_4bool = false;
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(false);
        models[5].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step6close()
    {
        #region 前置
        doFunctionName = "chongxinkaishi";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(step6_1bool);
        buttons[2].SetActive(step6_2bool);
        buttons[3].SetActive(step6_3bool);
        buttons[4].SetActive(step6_4bool);
        if (step6_1bool == false && step6_2bool == false && step6_3bool == false && step6_4bool == false)
        {
            step7();
        }
    }
    private void step7()
    {
        #region 前置
        doFunctionName = "step7_2";
        thisTime = 6.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step7_2()
    {
        #region 前置
        doFunctionName = "step7_3";
        thisTime = 4.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[5];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step7_3()
    {
        #region 前置
        doFunctionName = "chongxinkaishi";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[5].SetActive(true);
    }
    private void chongxinkaishi()
    {
        closeAll();
        step1();
    }
}
