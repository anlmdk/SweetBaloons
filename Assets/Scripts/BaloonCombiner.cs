using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonCombiner : MonoBehaviour
{
    private int layerIndex;

    private BaloonInformation info;

    public ParticleSystem mergeEffect;

    private void Awake()
    {
        info = GetComponent<BaloonInformation>();
        layerIndex = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            BaloonInformation _info = collision.gameObject.GetComponent<BaloonInformation>();
            if (_info != null)
            {
                if (_info.BaloonIndex == info.BaloonIndex)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        GameManager.Instance.IncreaseScore(info.PointsWhenAnnihilated);

                        if (info.BaloonIndex == BaloonSelector.Instance.Baloons.Length - 1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedBaloon(info.BaloonIndex), GameManager.Instance.transform);
                            go.transform.position = middlePosition;

                            ParticleSystem effectInstance = Instantiate(mergeEffect, middlePosition, Quaternion.identity);
                            effectInstance.Play();

                            ColliderInformation informer = go.GetComponent<ColliderInformation>();

                            if (informer != null)
                            {
                                informer.wasCombinedIn = true;
                            }
                            
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedBaloon(int index)
    {
        GameObject go = BaloonSelector.Instance.Baloons[index + 1];
        return go;
    }
}
