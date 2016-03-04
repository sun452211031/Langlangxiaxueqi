using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class manager4_1 : MonoBehaviour
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
    }
    void OnBecameVisible()
    {
        #region 雾效设置
        RenderSettings.fogColor = new Color(0.1f, 0.16f, 0.31f, 1);
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.0008f;
        RenderSettings.fogStartDistance = 0;
        RenderSettings.fogEndDistance = 300;
        #endregion
        if (imageTargetManeger.nowImageTarget != 1)
        {
            closeAll();
            doFunctionName = "";
            imageTargetManeger.nowImageTarget = 1;
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
        thisTime = 7.3f;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[0].SetActive(true);
        models[1].SetActive(true);
        models[2].SetActive(true);
        models[3].SetActive(true);
        models[4].SetActive(true);
        models[5].SetActive(true);
        models[6].SetActive(true);
        models[0].animation.Play("Take 001");
        models[1].animation.Play("Take 001");
        models[2].animation.Play("Take 001");
        models[4].animation.Play("Remove");
        models[5].animation.Play("Remove");
        models[6].renderer.sharedMaterial.color = new Color(0.82f, 0.4f, 0.24f, 1);
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
        models[0].animation.Play("Take 001");
        models[1].animation.Play("Take 001");
        models[2].animation.Play("Take 001");
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
    }
    private void step2()
    {
        #region 前置
        doFunctionName = "step1_2";
        thisTime = 16;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[1].animation.CrossFade("Take 002");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        thisAudioSource.clip = dubs[1];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step3()
    {
        #region 前置
        doFunctionName = "step1_2";
        thisTime = 38;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[2].animation.CrossFade("Take 002");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        thisAudioSource.clip = dubs[2];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
    private void step4()
    {
        #region 前置
        doFunctionName = "step1_2";
        thisTime = 38;
        canTimeInvoke = true;
        timeInvoke = 0;
        #endregion
        models[3].animation.CrossFade("Take 001");
        models[4].animation.Play("Take 001");
        models[5].animation.Play("Take 001");
        models[6].animation.Play("Take 001");
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        thisAudioSource.clip = dubs[3];
        thisAudioSource.Play();
        Invoke(doFunctionName, thisTime);
    }
}
