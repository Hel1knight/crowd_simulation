using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public bool LerpColor;
    public PosAgent Pos;
    public float LerpValue = 0;
    public int maxValue = 10;
    private Material mat;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pos.Started == false)
        {
            return;
        }

        int x = (int) transform.position.x;
        int z = (int) transform.position.z;
        if (x >= 0 && x < Pos.Pos.Length && z >= 0 && z < Pos.Pos[0].Length)
        {


            int countAgent = Pos.Pos[x][z];

            if (countAgent >= maxValue)
            {
                LerpValue = 1;
            }
            else
            {
                LerpValue = (float)countAgent / (float)maxValue;
            }

            mat.color = Color.Lerp(Color.blue, Color.red, LerpValue);

        }
    }

}
