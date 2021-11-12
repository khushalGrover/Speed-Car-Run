using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class CurvedText : MonoBehaviour
{
	public TMP_Text textComp;
    // Update is called once per frame
    void Update()
    {
        textComp.ForceMeshUpdate();
        var textInfo = textComp.textInfo;
       

        for(int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo =textInfo.characterInfo[i];
            if(!charInfo.isVisible)
            {
                continue;
            }
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for(int j=0; j< 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time*2f + orig.x*0.01f) * 50f, 0);
            }
        }

        for(int l= 0; l< textInfo.meshInfo.Length; ++l)
        {
            var meshInfo = textInfo.meshInfo[l];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComp.UpdateGeometry(meshInfo.mesh, l);
        }
    }
}
