using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuyItem : MonoBehaviour
{
    [SerializeField] Transform itemNewTransform;
    [SerializeField] private ParticleSystem confettiVFX;
    private Animator anim;
    [SerializeField] GameObject temp;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.CompareTag("Selled");
        Items collidedItem = other.GetComponent<Items>();
        if (collidedItem == null) return;
        if (other.gameObject.CompareTag("Collected"))
        {
            AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
            temp = other.gameObject;
            temp.gameObject.GetComponent<ItemSwipe>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ItemBought());
        }
    }
    IEnumerator ItemBought()
    {
        if (anim != null)
            anim.SetTrigger("takeMoney");
        StaticEvents.onSellItem?.Invoke(temp.gameObject.GetComponent<ItemValue>().itemValue);
         confettiVFX.Play();
        yield return new WaitForSeconds(0.2f);
        yield return null;
        temp.gameObject.transform.SetParent(itemNewTransform);
        //  temp.transform.localPosition = Vector3.zero;
        temp.transform.DOLocalMove(Vector3.zero, 0.1f);
        //  temp.transform.DOKill(true);
        temp = null;
    }
}
