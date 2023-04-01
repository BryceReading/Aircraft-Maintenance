using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using UnityEngine.UIElements;
<<<<<<< Updated upstream
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEditor.ProBuilder;
using UnityEditor;
using UnityEditor.EditorTools;
=======
using UnityEditor;
>>>>>>> Stashed changes
using TMPro;
using System.Linq;

[RequireComponent(typeof(LoadModel))]
public class AircraftUILoading : MonoBehaviour
{
    LoadModel loaderCode;
    Vector3[] locations = new Vector3[6];
    Camera[] cameras = new Camera[7];
    //GameObject[] currentLoaded = new GameObject[5];
    [HideInInspector]
    public RenderTexture[] displays = new RenderTexture[5];
    public int currentModel = 0;
    private int loadedModel = 0;

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
    }

    /*private void initLocations()
    {
        locations[0] = new Vector3(14701.26f, 1182.201f, -2357.01f);
        locations[1] = new Vector3(14701.26f, 1082.201f, -2357.01f);
        locations[2] = new Vector3(14801.26f, 1182.201f, -2357.01f);
        locations[3] = new Vector3(14801.26f, 1082.201f, -2357.01f);
        locations[4] = new Vector3(14901.26f, 1182.201f, -2357.01f);
    }

    

    public void loadViews(int model)
    {
        for(int i = 0; i< loaderCode.nameOf.Length; i++)
        {
            Destroy(currentLoaded[i]);
            currentLoaded[i] = loaderCode.loadViewModel(loaderCode.modelList[model], i, locations[i]);
            currentLoaded[i].layer = 7;
            currentLoaded[i].AddComponent<RotateCode>();
            Bounds bounds = currentLoaded[i].GetComponent<MeshFilter>().mesh.bounds;

            cameras[i].transform.position = new Vector3(currentLoaded[i].transform.position.x, currentLoaded[i].transform.position.y, currentLoaded[i].transform.position.z - bounds.size.z * currentLoaded[i].transform.localScale.z);

            float maxDimension = Mathf.Max(bounds.size.x * currentLoaded[i].transform.localScale.x, bounds.size.y * currentLoaded[i].transform.localScale.y, bounds.size.z * currentLoaded[i].transform.localScale.z);
            cameras[i].orthographicSize = maxDimension;
            transform.Find("Aircraft Model Parts").Find(loaderCode.nameOf[i]).GetComponent<RawImage>().texture = cameras[i].activeTexture;
        }
        transform.Find("Aircraft Model").Find("Text").GetComponent<Text>().text = loaderCode.modelList[model];
    }*/

    public int CheckLoop(int model)
    {
        if (model >= loaderCode.modelList.Count) { model = 0; }
        else if (model < 0) { model = loaderCode.modelList.Count - 1; }
        return model;
    }

    GameObject[] currentLoaded2 = new GameObject[6];

    private void initCameras(int length)
    {
        for (int i = 0; i< cameras.Length; i++) { Destroy(cameras[i].gameObject); }
        cameras = new Camera[length];
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

        for (int i = 0; i< length; i++)
        {
            cameras[i] = Instantiate<GameObject>(cameras[0].transform.gameObject, cameras[0].transform.position, Quaternion.identity).GetComponent<Camera>();
            cameras[i].targetTexture = Instantiate<RenderTexture>(cameras[0].activeTexture);
        }
    }

    private void initLocations(int length)
    {
        locations = new Vector3[length];
        for (int i = 0; i< length; i+=2)
        {
            locations[i] = new Vector3(14701.26f + 100*i, 1182.201f, -2357.01f);
            if (i + 1 != length) { locations[i + 1] = new Vector3(14701.26f + 100 * i, 1082.201f, -2357.01f); }
        }
    }

    public void SelectModel()
    {
        loaderCode.swapModel(loaderCode.modelList[currentModel]);
        loadedModel = currentModel;
    }

    public void loadViews2(int model)
    {
        privateLoad(model);
    }

    public void loadViews2()
    {
        privateLoad(loadedModel);
    }

    private void privateLoad(int model)
    {
        Renderer[] renderers;

        Destroy(currentLoaded2[0]);
        for(int j = 0; j < currentLoaded2.Length; j++) { Destroy(currentLoaded2[j]); }
        Resources.UnloadUnusedAssets();
        GameObject Helicopter = Resources.Load<GameObject>("Aircraft/" + loaderCode.modelList[model]);

        currentLoaded2 = new GameObject[Helicopter.transform.childCount];
        //initCameras(currentLoaded2.Length);
        initLocations(currentLoaded2.Length);
        currentLoaded2[0] = Instantiate(Helicopter, locations[0], Quaternion.identity);
        currentLoaded2[0].SetLayerRecursively(7);
        currentLoaded2[0].AddComponent<RotateCode>();

        transform.Find("Aircraft Model").GetComponent<RawImage>().texture = cameras[0].activeTexture;
        transform.Find("Aircraft Model").Find("Text").GetComponent<Text>().text = loaderCode.modelList[model];

        renderers = Helicopter.GetComponentsInChildren<MeshRenderer>();
        Bounds bounds = renderers[0].bounds;


        List<MeshFilter> children = currentLoaded2[0].transform.GetComponentsInChildren<MeshFilter>().ToList<MeshFilter>();
        Vector3 extents = Vector3.zero;
        foreach (MeshFilter child in children)
        {
            Vector3 abs = new Vector3(Mathf.Abs(child.transform.localPosition.x), Mathf.Abs(child.transform.localPosition.y), Mathf.Abs(child.transform.localPosition.z));
            Vector3 t = abs + child.sharedMesh.bounds.extents;
            extents.x = t.x > extents.x ? t.x : extents.x;
            extents.y = t.y > extents.y ? t.y : extents.y;
            extents.z = t.z > extents.z ? t.z : extents.z;
        }

        float size = extents.x > extents.z ? extents.x : extents.z;
        size = size > extents.y ? size : extents.y;
        size = size + 5;
        cameras[0].orthographicSize = size;
        Vector3 pos = (currentLoaded2[0].transform.position);
        cameras[0].transform.position = new Vector3(pos.x,pos.y,pos.z - size);






        /*for (int x = 1; x < renderers.Length; x++)
        {
            bounds.Encapsulate(renderers[x].bounds);
        }
        Vector3 globalPos = currentLoaded2[0].transform.TransformPoint(bounds.center);
        float maxDimension = Mathf.Max(Mathf.Abs(bounds.size.x * currentLoaded2[0].transform.localScale.x), Mathf.Abs(bounds.size.y * currentLoaded2[0].transform.localScale.y), Mathf.Abs(bounds.size.z * currentLoaded2[0].transform.localScale.z));
        *//*cameras[0].transform.position = new Vector3(globalPos.x, globalPos.y, globalPos.z - maxDimension * Mathf.Abs(currentLoaded2[0].transform.localScale.x));
        cameras[0].orthographicSize = maxDimension;*//*

        int i = 0;
        try
        {
            foreach (Transform child in Helicopter.transform)
            {
                if (child.name != "Armature") //Array.IndexOf(loaderCode.nameOf, child.name) > 0
                {
                    i++;
                    currentLoaded2[i] = Instantiate(child.gameObject, locations[i], child.rotation);
                    currentLoaded2[i].layer = 7;
                    currentLoaded2[i].AddComponent<RotateCode>();
                    bounds = currentLoaded2[i].GetComponent<MeshFilter>().mesh.bounds;

                    maxDimension = Mathf.Max(Mathf.Abs(bounds.size.x * currentLoaded2[i].transform.localScale.x), Mathf.Abs(bounds.size.y * currentLoaded2[i].transform.localScale.y), Mathf.Abs(bounds.size.z * currentLoaded2[i].transform.localScale.z));


                    globalPos = currentLoaded2[i].transform.TransformPoint(bounds.center);

                    cameras[i].transform.position = new Vector3(globalPos.x, globalPos.y, globalPos.z - maxDimension * Mathf.Abs(currentLoaded2[i].transform.localScale.x));

                    cameras[i].orthographicSize = maxDimension;
                    transform.Find("Aircraft Model Parts").Find(loaderCode.nameOf[i - 1]).GetComponent<RawImage>().texture = cameras[i].activeTexture;
                }
            }
        }
        catch { }*/
        currentModel = model;
    }

}
