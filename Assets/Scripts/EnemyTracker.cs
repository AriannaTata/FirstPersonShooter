using UnityEngine;
using UnityEngine.UI;

public class EnemyTracker : MonoBehaviour
{
    public Transform[] enemies;
    public RectTransform[] arrows;
    public float offsetAlto = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            foreach (RectTransform arrow in arrows)
            {
                if(arrow != null)
                {
                    arrow.gameObject.SetActive(false);
                }
            }
            return;
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                if(arrows[i]!= null)
                {
                    arrows[i].gameObject.SetActive(false);
                    continue;
                }
                    
            }
            Vector3 worldPos = enemies[i].position + Vector3.up * offsetAlto;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            if (screenPos.z > 0)
            {
                arrows[i].gameObject.SetActive(true);
                arrows[i].position = screenPos;
            }
            else
            {
                arrows[i].gameObject.SetActive(false);
            }
        }
       
    }
}
