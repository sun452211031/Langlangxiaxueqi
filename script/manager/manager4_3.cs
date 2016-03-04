using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager4_3 : MonoBehaviour
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
        #region 雾效设置
        RenderSettings.fogDensity = 0;
        #endregion
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
        #region 雾效设置
        RenderSettings.fogDensity = 0;
        #endregion
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
        thisTime = 12.1f;
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
        doFunctionName = "step1_2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(true);
        models[1].SetActive(false);
        models[2].SetActive(false);
        models[3].SetActive(false);
        models[4].SetActive(false);
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        buttons[3].SetActive(true);
        buttons[4].SetActive(false);
        thisAudioSource.Stop();
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(false);
        models[1].SetActive(true);
        models[1].animation.Play("Take 001");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(true);
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
    }
    private void step3()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(false);
        models[2].SetActive(true);
        models[2].animation.Play("Take 001");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(true);
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(false);
        models[3].SetActive(true);
        models[3].animation.Play("Take 001");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(true);
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
    }
    private void step5()
    {
        #region 前置
        doFunctionName = "step2";
        thisTime = 0;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(false);
        models[4].SetActive(true);
        models[4].animation.Play("Take 001");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[4].SetActive(true);
        thisAudioSource.clip = dubs[4];
        thisAudioSource.Play();
    }
}
