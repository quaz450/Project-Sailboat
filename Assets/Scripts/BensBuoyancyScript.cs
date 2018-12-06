using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BensBuoyancyScript : MonoBehaviour {

    // Use this for initialization
    Rigidbody rb;
    public float waterline = 0;
    public float viscosity = 1000;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3[] corners = GetColliderVertexPositions(this.gameObject);
        List<Vector3> underWaterCorners = GetUnderwaterCorners(corners);
        if (underWaterCorners.Count > 0)
        {
            Vector3 underWaterCenter = GetCentroid(underWaterCorners);
            Vector3 buoyancy = new Vector3(0, 20, 0);
            rb.AddForceAtPosition(new Vector3(0, 20, 0), underWaterCenter, ForceMode.Force);
            rb.AddForceAtPosition(rb.velocity * -1 * viscosity, underWaterCenter, ForceMode.Force);
            Debug.DrawLine(underWaterCenter, underWaterCenter + buoyancy, Color.green);
        }
       
        //Debug.DrawLine(underWaterCenter, rb.velocity * -1 * viscosity, Color.red);
        //rb.AddForce(0, 20, 0);
        //rb.AddForce(rb.velocity * -1 * viscosity);
        

    }

    public Vector3[] GetColliderVertexPositions(GameObject obj)
    {
        BoxCollider b = obj.GetComponent<BoxCollider>(); //retrieves the Box Collider of the GameObject called obj
        Vector3[] vertices = new Vector3[8];
        vertices[0] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[1] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[2] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[3] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[4] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[5] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[6] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f);
        vertices[7] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f);

        return vertices;
    }

    public List<Vector3> GetUnderwaterCorners(Vector3[] corners)
    {
        List<Vector3> uwCorners = new List<Vector3>();
        foreach (Vector3 corner in corners)
        {
            if(corner.y < waterline)
            {
                uwCorners.Add(corner);
            }
        }
        return uwCorners;
    }

    public Vector3 GetCentroid(List<Vector3> points)
    {
        Vector3 sum = Vector3.zero;
        foreach( Vector3 point in points)
        {
            sum += point;
        }
        return sum / (float) points.Count;
    }
}
