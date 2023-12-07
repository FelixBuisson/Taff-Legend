using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] Transform PivotTop;
    [SerializeField] Transform PivotBottom;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize;
    [SerializeField] float hookPower;
    float hookProgress;
    float hookPullVeloc;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] public float hookDegradation;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform ProgressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 30f;

    private void Start()
    {
        //Resize(); Scale Y HookZone = 0.2909091
        hookPosition = 3f;
    }

    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(PivotTop.position, PivotBottom.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;
    }

    private void Update()
    {
        if (pause) { return; }

        //smoothMotion = 0.1f;
        //hookDegradation = 1f;
        //hookPower = 1f;
        //hookSize = 0.1f;

        Fish();
        Hook();
        ProgressCheck();
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0) {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(PivotBottom.position, PivotTop.position, fishPosition);
    }

    void Hook()
    {
        if (Input.GetKey(KeyCode.Space)) {
            hookPullVeloc += hookPullPower * Time.deltaTime;
        }
        hookPullVeloc -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVeloc;

        if (hookPosition - hookSize / 2 < 0f && hookPullVeloc < 0f) {
            hookPullVeloc = 0f;
        }
        if (hookPosition + hookSize / 2 >= 1f && hookPullVeloc > 0f) {
            hookPullVeloc = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(PivotBottom.position, PivotTop.position, hookPosition);
    }

    private void ProgressCheck()
    {
        Vector3 ls = ProgressBarContainer.localScale;
        ls.y = hookProgress;
        ProgressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max) {
            hookProgress += hookPower * Time.deltaTime;
        } else {
            hookProgress -= hookDegradation * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if (failTimer < 0f)
                Escaped();
        }

        if (hookProgress >= 1)
        {
            Catched();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Catched()
    {
        pause = true;
        Debug.Log("Fish catched !");
    }

    private void Escaped()
    {
        pause = true;
        Debug.Log("Fish escaped !");
    }
}