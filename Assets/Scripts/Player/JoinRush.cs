using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRush : MonoBehaviour
{
    public static JoinRush instance;
    public List<GameObject> chibis = new List<GameObject>();
    public float delay = 0.25f;
    public float originDelay = 0.7f;
    private Vector3 newPos;
    private Vector3 pos;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("zklxmgfkasmfka");
            MoveListObjects();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            MoveOrigin();
        }
    }

    public void StackChibi(GameObject other, int index)
    {
        other.transform.parent = transform;
        newPos = chibis[index].transform.localPosition;
        newPos.z += 1.5f;
        other.transform.localPosition = newPos;
        chibis.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }
    
    private IEnumerator MakeObjectsBigger()
    {
        for(int i = chibis.Count - 1; i > 0; i--)
        {
            scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            chibis[i].transform.DOScale(scale, 0.1f).OnComplete(() =>
             chibis[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListObjects()
    {
        for(int i = 1; i < chibis.Count; i++)
        {
            pos = chibis[i].transform.localPosition;
            pos.x = chibis[i - 1].transform.localPosition.x;
            chibis[i].transform.DOLocalMove(pos, delay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < chibis.Count; i++)
        {
            pos = chibis[i].transform.localPosition;
            pos.x = chibis[0].transform.localPosition.x;
            chibis[i].transform.DOLocalMove(pos, originDelay);
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


}
