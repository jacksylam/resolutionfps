using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Cpu : MonoBehaviour {

    PerformanceCounter cpuCounter;
    PerformanceCounter ramCounter;

	// Use this for initialization
	void Start () {
        PerformanceCounterCategory.Exists("PerformanceCounter");

        //cpuCounter = new PerformanceCounter();
        //cpuCounter.CategoryName = "Processor";
        //cpuCounter.CounterName = "% Processor Time";
        //cpuCounter.InstanceName = "_Total";

          cpuCounter = new PerformanceCounter(
         "Processor",
         "% Processor Time");

        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
	}
	
	// Update is called once per frame
	void Update () {
       

        StartCoroutine(getcpuAndram());
	}

    private  IEnumerator getcpuAndram() {
        getcpuUsage();
        getramUsage();
        yield return new WaitForSeconds(1);
        UnityEngine.Debug.Log("cpu: " + getcpuUsage() + " ram: " + getramUsage());
    }

    private string getcpuUsage() {
        return cpuCounter.NextValue().ToString();
    }

    private string getramUsage() {
        return ramCounter.NextValue().ToString();
    }
}
