using UnityEngine;

public class WayPoints : MonoBehaviour {
 
     // put the points from unity interface
     public Transform[] wayPointList;
 
     public int currentWayPoint = 0; 
     Transform targetWayPoint;
	public bool active = false;
     public float speed = 40f; 
     // Use this for initialization
	public WayPoints (Transform[] wayPointList, float speed)
	{
		this.wayPointList = wayPointList;
		this.speed = speed;
	}
	public WayPoints (Transform[] wayPointList)
	{
		this.wayPointList = wayPointList;
	}
	public void CalculateSpeedByTime(float time){
		float TotalDistance=0;
		for(int i =1;i<wayPointList.Length;i++){
			TotalDistance += Vector3.Distance(wayPointList[i-1].position,wayPointList[i].position);
		}
		speed = TotalDistance / time;
	}
	void Active(){
		active = true;
		currentWayPoint = 1;
		transform.localScale = new Vector3 (1, 1, 1);
		transform.position = wayPointList[0].position;
		targetWayPoint = wayPointList [currentWayPoint];

	}
	void Disable(){
		active = false;
		transform.localScale = new Vector3 (0, 0, 0);
	}
     void Start () {
		currentWayPoint = 1;
		transform.position = wayPointList[0].position;
		targetWayPoint = wayPointList [currentWayPoint];
     }
     
     // Update is called once per frame
     void Update () {
		if(active)
           walk();
     }
 
     void walk(){


         // rotate towards the target
         transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
 
         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
		if(transform.position == targetWayPoint.position)
		{
			currentWayPoint ++ ;
			if(currentWayPoint<wayPointList.Length)
				targetWayPoint = wayPointList[currentWayPoint];
			else Start();
		}
     } 
 }