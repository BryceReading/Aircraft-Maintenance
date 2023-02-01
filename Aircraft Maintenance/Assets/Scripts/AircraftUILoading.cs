using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LoadModel))]
public class AircraftUILoading : MonoBehaviour
{
    LoadModel loaderCode;
    Vector3[] locations = new Vector3[5];
    Camera[] cameras = new Camera[5];
    GameObject[] currentLoaded = new GameObject[5];
    [HideInInspector]
    public RenderTexture[] displays = new RenderTexture[5];
    public int currentModel;

    private void Start()
    {
        cameras[0] = new GameObject().AddComponent<Camera>();
        cameras[0].cullingMask = 1 << 7;
        cameras[0].transform.position = locations[0];
        cameras[0].orthographic = true;
        cameras[0].targetDisplay = 2;
        cameras[0].clearFlags = CameraClearFlags.SolidColor;
        Color tempColour = Color.gray;
        tempColour.a = 0;
        cameras[0].backgroundColor = tempColour;
        cameras[0].targetTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        cameras[0].gameObject.AddComponent<Light>().type = LightType.Directional;
        cameras[0].gameObject.GetComponent<Light>().intensity = 0.25f;
        cameras[0].gameObject.GetComponent<Light>().cullingMask = 1 << 7;
        loaderCode = GetComponent<LoadModel>();

        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i] = Instantiate<GameObject>(cameras[0].transform.gameObject, cameras[0].transform.position, Quaternion.identity).GetComponent<Camera>();
            cameras[i].targetTexture = Instantiate<RenderTexture>(cameras[0].activeTexture);
        }
        initLocations();
    }

    private void initLocations()
    {
        locations[0] = new Vector3(14701.26f, 1182.201f, -2357.01f);
        locations[1] = new Vector3(14701.26f, 1082.201f, -2357.01f);
        locations[2] = new Vector3(14801.26f, 1182.201f, -2357.01f);
        locations[3] = new Vector3(14801.26f, 1082.201f, -2357.01f);
        locations[4] = new Vector3(14901.26f, 1182.201f, -2357.01f);
    }

    public bool CheckLoop(int model)
    {
        if (model >= loaderCode.modelList.Count) { model = 0; }
        else if (model < 0) { model = loaderCode.modelList.Count - 1; }
        return model == currentModel;
    }

    public void loadViews(int model)
    {
        for(int i = 0; i< loaderCode.nameOf.Length; i++)
        {
            Destroy(currentLoaded[i]);
            currentLoaded[i] = loaderCode.loadViewModel(loaderCode.modelList[model], loaderCode.nameOf[i], locations[i]);
            currentLoaded[i].layer = 7;
            currentLoaded[i].AddComponent<RotateCode>();
            Bounds bounds = currentLoaded[i].GetComponent<MeshFilter>().mesh.bounds;

            cameras[i].transform.position = new Vector3(currentLoaded[i].transform.position.x, currentLoaded[i].transform.position.y, currentLoaded[i].transform.position.z - bounds.size.z * currentLoaded[i].transform.localScale.z);

            float maxDimension = Mathf.Max(bounds.size.x * currentLoaded[i].transform.localScale.x, bounds.size.y * currentLoaded[i].transform.localScale.y, bounds.size.z * currentLoaded[i].transform.localScale.z);
            cameras[i].orthographicSize = maxDimension;
            transform.Find("Aircraft Model Parts").Find(loaderCode.nameOf[i]).GetComponent<RawImage>().texture = cameras[i].activeTexture;
        }
        transform.Find("Aircraft Model").Find("Text").GetComponent<Text>().text = loaderCode.modelList[model];
    }

}
