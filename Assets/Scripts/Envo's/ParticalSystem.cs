using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem itemPortalPartical;
    [SerializeField] ParticleSystem itemFeedPartical;
    [SerializeField] ParticleSystem itemDeadPartical;
    [SerializeField] ParticleSystem itemNosPartical;

    private void OnEnable()
    {
        //  StaticEvents.UpgradePlayer += PlayPortalPartical;

    }
    private void OnDisable()
    {
        //  StaticEvents.UpgradePlayer -= PlayPortalPartical;
    }
    private void PlayPortalPartical()
    {
        Debug.Log("amo");
        if (itemPortalPartical == null) return;
        itemPortalPartical.Play();
    }
    private void PlayFeedPartical()
    {
        if (itemFeedPartical == null) return;
        itemFeedPartical.Play();
    }
    private void PlayDeadPartical()
    {
        if (itemDeadPartical == null) return;
        itemDeadPartical.Play();
    }
    private void PlayNosPartical()
    {
        if (itemNosPartical == null) return;
        itemNosPartical.Play();
    }
}
