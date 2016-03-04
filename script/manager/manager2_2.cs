using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager2_2 : MonoBehaviour
{
    private bool isEditor;
    public AudioClip[] dubs;
    public GameObject[] models;
    public GameObject[] rawImages;
    public GameObject[] buttons;
    private AudioSource thisAudioSource;
    private string doFunctionName = "";
    private AudioSource buttonSoundeffect;
    private float timeInvoke;
    private bool canTimeInvoke = false;
    private float thisTime;
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
                    if (thisRaycastHit.collider.gameObject.tag == "button2")
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
                        if (thisRaycastHit.collider.gameObject.tag == "button2")
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
        for (int i = 0; i < rawImages.Length; i++)
        {
            rawImages[i].SetActive(false);
        }
    }
    void OnBecameVisible()
    {
        if (imageTargetManeger.nowImageTarget != 2)
        {
            closeAll();
            doFunctionName = "";
            imageTargetManeger.nowImageTarget = 2;
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
        foreach (GameObject component in rawImages)
        {
            component.GetComponent<RawImage>().enabled = true;
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
        foreach (GameObject component in rawImages)
        {
            component.GetComponent<RawImage>().enabled = false;
        }
    }
    private void step1()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 5.4f;
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
        thisTime = 5.2f;
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
        thisTime = 11.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(false);
        buttons[0].SetActive(false);
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
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[3].SetActive(true);
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step4_2";
        thisTime = 12.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[3].SetActive(false);
        models[1].SetActive(false);
        models[2].SetActive(true);
        models[3].SetActive(true);
        models[2].animation.Play("Take 001");
        thisAudioSource.clip = dubs[3];
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
        buttons[4].SetActive(true);
    }
    private void step5()
    {
        #region 前置
        doFunctionName = "step5_2";
        thisTime = 3;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[4].SetActive(false);
        models[2].SetActive(false);
        models[3].SetActive(false);
        models[1].SetActive(true);
        models[1].animation.Play("Take 001");
        Invoke(doFunctionName, thisTime);
    }
    private void step5_2()
    {
        #region 前置
        doFunctionName = "step6";
        thisTime = 11;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[0].SetActive(true);
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step6()
    {
        #region 前置
        doFunctionName = "step6_2";
        thisTime = 3;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[0].SetActive(false);
        Invoke(doFunctionName, thisTime);
    }
    private void step6_2()
    {
        #region 前置
        doFunctionName = "step6_3";
        thisTime = 8;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[1].SetActive(true);
        thisAudioSource.clip = dubs[5];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step6_3()
    {
        #region 前置
        doFunctionName = "step7";
        thisTime = 6;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[1].SetActive(false);
        rawImages[2].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step7()
    {
        #region 前置
        doFunctionName = "step7_2";
        thisTime = 5.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[2].SetActive(false);
        models[1].SetActive(false);
        models[0].SetActive(true);
        thisAudioSource.clip = dubs[6];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step7_2()
    {
        #region 前置
        doFunctionName = "step8";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(true);
    }
    private void step8()
    {
        #region 前置
        doFunctionName = "step8_2";
        thisTime = 12;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(false);
        models[0].animation.Play("Take 002");
        Invoke(doFunctionName, thisTime);
    }
    private void step8_2()
    {
        #region 前置
        doFunctionName = "step8_3";
        thisTime = 5;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[4].SetActive(true);
        Invoke(doFunctionName, thisTime);
    }
    private void step8_3()
    {
        #region 前置
        doFunctionName = "step8_4";
        thisTime = 4.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[7];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step8_4()
    {
        #region 前置
        doFunctionName = "chongxinkaishi";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[2].SetActive(true);
    }
    private void chongxinkaishi()
    {
        closeAll();
        step1();
    }
}
