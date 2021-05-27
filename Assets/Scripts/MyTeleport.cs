using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HTC.UnityPlugin.Vive
{

    public class MyTeleport : Teleportable
    {
        [SerializeField]
        float Speed;
        [SerializeField]
        float CoolDown;

        public override IEnumerator StartTeleport(Vector3 position, float duration)
        {
            while (true)
            {
                target.position = Vector3.MoveTowards(target.position, position, Speed * Time.deltaTime);

                Vector3 v = position;
                v.y = target.position.y;

                if (Vector3.Distance(target.position, v) < 0.1f)
                {
                    yield return new WaitForSeconds(CoolDown);
                    teleportCoroutine = null;
                    yield break;

                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}
