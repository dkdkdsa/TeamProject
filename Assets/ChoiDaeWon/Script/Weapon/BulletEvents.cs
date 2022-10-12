using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class BulletEvents : MonoBehaviour
{

    #region È­¿°Åº
    [SerializeField] private float[] fireDotDamage;
    [SerializeField] private float[] fireDotDamageDuration;
    #endregion

    #region Ice
    [Range(0f, 1f)][SerializeField] private float[] freezPower;
    [SerializeField] private float[] freezDuration;
    #endregion

    private bool isIce;
    private bool isDotDeal;
    private float currentFireDuration;
    private IEnumerator fireDotDamageCO;

    public void FireBullet(Enemy enemy)
    {

        currentFireDuration += fireDotDamageDuration[Upgrader.instance.FindUpGradeCount(BulletType.Fire)];
        
        if(isDotDeal == false)
        {

            StartCoroutine(FireDotDamage(Upgrader.instance.FindUpGradeCount(BulletType.Fire), enemy));

        }

    }

    public void Ice(Enemy enemy) 
    {

        if(isIce == false)
        {
            
            StartCoroutine(ThawCo(enemy, Upgrader.instance.FindUpGradeCount(BulletType.Ice)));

        }
        
    }

    IEnumerator ThawCo(Enemy enemy, int upgradeCount)
    {

        isIce = true;
        enemy.currentSpeed = enemy.currentSpeed - (enemy.currentSpeed * freezPower[upgradeCount]);
        yield return new WaitForSeconds(freezDuration[upgradeCount]);
        enemy.currentSpeed = enemy.originSpeed;
        isIce = false;

    }
    IEnumerator FireDotDamage(int upgradeCount, Enemy enemy)
    {

        yield return null;
        isDotDeal = true;

        while(currentFireDuration > 0)
        {

            enemy.TakeAttack(fireDotDamage[upgradeCount]);
            yield return new WaitForSeconds(0.3f);
            currentFireDuration -= 0.3f;

        }
        
        currentFireDuration = 0;

        isDotDeal = false;

    }

}
