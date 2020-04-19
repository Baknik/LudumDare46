using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class DepthSorter : MonoBehaviour
{
    public float zDepthIncrement = 0.001f;

    private void Update()
    {
        #if UNITY_EDITOR
        if (!EditorApplication.isPlaying) this.Execute();
        #endif
    }

    private void FixedUpdate()
    {
        this.Execute();
    }

    private void Execute()
    {
        List<DepthSortedObject> depthSortedObjects = new List<DepthSortedObject>();
        foreach (DepthSorted ds in GameObject.FindObjectsOfType<DepthSorted>())
        {
            depthSortedObjects.Add(new DepthSortedObject(ds, ds.transform));
        }
        float zDepth = 0f;
        depthSortedObjects.Sort();
        for (int i = 0; i < depthSortedObjects.Count; i++)
        {
            DepthSortedObject dso = depthSortedObjects[i];
            dso.Transform.position = new Vector3(dso.Transform.position.x, dso.Transform.position.y, zDepth);
            zDepth += zDepthIncrement;

            zDepth = this.SortChildren(dso.Transform, zDepth);
        }
    }

    private float SortChildren(Transform transform, float zDepth)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);

            if (childTransform.gameObject.GetComponent<Renderer>() != null)
            {
                childTransform.position = new Vector3(childTransform.position.x, childTransform.position.y, zDepth);
                zDepth += zDepthIncrement;
            }

            zDepth = this.SortChildren(childTransform, zDepth);
        }

        return zDepth;
    }
}

public class DepthSortedObject : IComparable
{
    public DepthSorted DepthSorted { get; set; }
    public Transform Transform { get; set; }

    public DepthSortedObject(DepthSorted depthSorted, Transform transform)
    {
        this.DepthSorted = depthSorted;
        this.Transform = transform;
    }

    // greater-than signifies that this object exists behind the other
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        DepthSortedObject other = obj as DepthSortedObject;
        if (other != null)
        {
            if ((int)(this.DepthSorted.SortingLayer) > (int)(other.DepthSorted.SortingLayer))
            {
                return 1;
            }
            else if ((int)(this.DepthSorted.SortingLayer) < (int)(other.DepthSorted.SortingLayer))
            {
                return -1;
            }
            else
            {
                if (this.Transform.position.y > other.Transform.position.y) return 1;
                else if (this.Transform.position.y == other.Transform.position.y) return 0;
                else return -1;
            }
        }
        else
        {
            throw new ArgumentException("Object is not a DepthSortedObject");
        }
    }
}