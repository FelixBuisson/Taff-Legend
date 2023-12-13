using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] Transform hook;
    float hookPosition;
    float hookProgress;
    float hookPullVeloc;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform ProgressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 60f;

    static private SelectionMenu select;

    private float finalSpeed = select.fish.speed + select.bait.malusSpeed;
    private float finalEndurance = select.fish.endurance + select.bait.malusEndurance;
    private float finalPower = select.rod.power + select.bait.bonusPower;
    private float finalSize = select.rod.size + select.bait.bonusSize;

    private void Start()
    {
        hookPosition = 3f;
        select = SelectionMenu.Instance;
    }

    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(PivotTop.position, PivotBottom.position);
        ls.y = (distance / ySize * finalSize);
        hook.localScale = ls;
    }

    private void Update()
    {
        if (pause) { return; }

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

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, finalSpeed);
        fish.position = Vector3.Lerp(PivotBottom.position, PivotTop.position, fishPosition);
    }

    void Hook()
    {
        if (Input.GetKey(KeyCode.Space)) {
            hookPullVeloc += hookPullPower * Time.deltaTime;
        }
        hookPullVeloc -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVeloc;

        if (hookPosition - finalSize / 2 < 0f && hookPullVeloc < 0f) {
            hookPullVeloc = 0f;
        }
        if (hookPosition + finalSize / 2 >= 1f && hookPullVeloc > 0f) {
            hookPullVeloc = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, finalSize/2, 1 - finalSize/2);
        hook.position = Vector3.Lerp(PivotBottom.position, PivotTop.position, hookPosition);
    }

    private void ProgressCheck()
    {
        Vector3 ls = ProgressBarContainer.localScale;
        ls.y = hookProgress;
        ProgressBarContainer.localScale = ls;

        float min = hookPosition - finalSize / 2;
        float max = hookPosition + finalSize / 2;

        if (min < fishPosition && fishPosition < max) {
            hookProgress += finalPower * Time.deltaTime;
        } else {
            hookProgress -= finalEndurance * Time.deltaTime;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Escaped()
    {
        pause = true;
        Debug.Log("Fish escaped !");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}