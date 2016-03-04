using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class loadlevel : MonoBehaviour, IPointerClickHandler
{
    public GameObject loading;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(loading)
        {
            loading.SetActive(true);
        }
        Application.LoadLevel(gameObject.name);
    }
}
