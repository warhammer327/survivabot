using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Shake(float duration, float magnitude){
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        
        while(elapsed<duration){
            float x = Random.Range(-2f,2f)*magnitude;
            float y = Random.Range(-2f,2f)*magnitude;
            transform.localPosition = new Vector3(originalPos.x+x,originalPos.y+y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
