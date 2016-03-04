using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager2_1 : MonoBehaviour
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
        //closeAll();
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
                    if (thisRaycastHit.collider.gameObject.tag == "button1")
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
                        if (thisRaycastHit.collider.gameObject.tag == "button1")
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
        if (imageTargetManeger.nowImageTarget != 1)
        {
            closeAll();
            doFunctionName = "";
            imageTargetManeger.nowImageTarget = 1;
        }
        canTimeInvoke = true;
        //Time.timeScale = 1;
        //thisAudioSource.enabled = true;
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
        //thisAudioSource.Play();
    }
    void OnBecameInvisible()
    {
        canTimeInvoke = false;
        //Time.timeScale = 0;
        CancelInvoke();
        //closeAll();
        //thisAudioSource.enabled = false;
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
        //thisAudioSource.Pause();
    }
    private void step1()
    {
        #region 前置
        doFunctionName = "step1_2";
        thisTime = 4.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(true);
        thisAudioSource.clip = dubs[0];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step1_2()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 4.5f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        //models[0].SetActive(true);
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step3";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        //doFunctionName = "step2";
        //models[0].SetActive(true);
        buttons[0].SetActive(true);
    }
    private void step3()
    {
        #region 前置
        doFunctionName = "step4";
        thisTime = 9.2f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        //doFunctionName = "step3";
        models[0].SetActive(false);
        models[1].SetActive(true);
        models[2].SetActive(true);
        buttons[0].SetActive(false);
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
        models[2].animation.Play("2-1Text01");
        Invoke(doFunctionName, thisTime);
    }
    private void step4()
    {
        //doFunctionName = "step4";
        //models[1].SetActive(true);
        //models[2].SetActive(true);
        #region 前置
        doFunctionName = "step5";
        thisTime = 5;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
        models[2].animation.Play("2-1Text01_2");
        Invoke(doFunctionName, thisTime);
    }
    private void step5()
    {
        //doFunctionName = "step5";
        //models[1].SetActive(true);
        //models[2].SetActive(true);
        #region 前置
        doFunctionName = "step6";
        thisTime = 7.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[3].SetActive(true);
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
        models[2].animation.Play("2-1Text01_2");
        Invoke(doFunctionName, thisTime);
    }
    private void step6()
    {
        //doFunctionName = "step6";
        //models[1].SetActive(true);
        //models[2].SetActive(true);
        //models[3].SetActive(true);
        #region 前置
        doFunctionName = "step7";
        thisTime = 7.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[4].SetActive(true);
        thisAudioSource.clip = dubs[5];
        thisAudioSource.Play();
        models[2].animation.Play("2-1Text01_2");
        Invoke(doFunctionName, thisTime);
    }
    private void step7()
    {
        //doFunctionName = "step7";
        //models[1].SetActive(true);
        //models[2].SetActive(true);
        //models[3].SetActive(true);
        //models[4].SetActive(true);
        #region 前置
        doFunctionName = "step7_2";
        thisTime = 12.8f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[5].SetActive(true);
        thisAudioSource.clip = dubs[6];
        thisAudioSource.Play();
        models[2].animation.Play("2-1Text01_2");
        Invoke(doFunctionName, thisTime);
    }
    private void step7_2()
    {
        #region 前置
        doFunctionName = "step9";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[4].SetActive(true);
    }
    public void step8()
    {
        //doFunctionName = "step8";
        #region 前置
        doFunctionName = "step9";
        thisTime = 4;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[0].SetActive(true);
        thisAudioSource.clip = dubs[7];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step9()
    {
        //doFunctionName = "step9";
        #region 前置
        doFunctionName = "step10";
        thisTime = 4.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[1].SetActive(true);
        thisAudioSource.clip = dubs[8];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step10()
    {
        //doFunctionName = "step10";
        #region 前置
        doFunctionName = "step11";
        thisTime = 4.8f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[2].SetActive(true);
        thisAudioSource.clip = dubs[9];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step11()
    {
        //doFunctionName = "step11";
        #region 前置
        doFunctionName = "step11_2";
        thisTime = 3.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        rawImages[3].SetActive(true);
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
        rawImages[5].SetActive(true);
    }
    public void step12()
    {
        //doFunctionName = "step12";
        #region 前置
        doFunctionName = "step12_2";
        thisTime = 7.5f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[1].SetActive(false);
        models[2].SetActive(false);
        models[3].SetActive(false);
        models[4].SetActive(false);
        models[5].SetActive(false);
        rawImages[0].SetActive(false);
        rawImages[1].SetActive(false);
        rawImages[2].SetActive(false);
        rawImages[3].SetActive(false);
        models[6].SetActive(true);
        models[6].animation.Play("Remove");
        thisAudioSource.clip = dubs[11];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step12_2()
    {
        //doFunctionName = "step12_2";
        //models[6].SetActive(true);
        #region 前置
        doFunctionName = "step13";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(true);
    }
    private void step13()
    {
        //doFunctionName = "step13";
        //models[6].SetActive(true);
        #region 前置
        doFunctionName = "step13_2";
        thisTime = 2.7f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        buttons[1].SetActive(false);
        models[6].animation.Play("Take 001");
        thisAudioSource.clip = dubs[12];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step13_2()
    {
        //doFunctionName = "step13_2";
        //models[6].SetActive(true);
        #region 前置
        doFunctionName = "step13_3";
        thisTime = 4.4f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[6].audio.Play();
        thisAudioSource.clip = dubs[13];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step13_3()
    {
        //doFunctionName = "step13_3";
        //models[6].SetActive(true);
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
