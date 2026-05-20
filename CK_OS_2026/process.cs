using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeSRTF
{
    public class Process
    {
        public string? ID           { get; private set; }
        public int arrivalTime      { get; private set; }
        public int burstTime        { get; private set; }
        public int remainingTime    { get; private set; }


        public int turnAroundTime => completionTime - arrivalTime;
        public int waitingTime    => turnAroundTime - burstTime;
        public int completionTime   { get; private set; }
        public int responseTime     { get; private set; }
        public int quantumTime      { get; private set; }
        public int priority         { get; private set; }

        public Process(string? ID, int arrivalTime, int burstTime)
        {
            this.ID = ID;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.remainingTime = burstTime;
            this.priority = 0; // gán mặc định bằng 0 để không bị lỗi null
        }

        // constructure riêng cho priority
        public Process(string? ID, int arrivalTime, int burstTime, int priority)
        {
            this.ID = ID;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.remainingTime = burstTime;
            this.priority = priority;
        }

        public void executeOneTick() => remainingTime--;     

        public void markResponse(int currentTime) => responseTime = currentTime - arrivalTime;
        
        public void markCompletion(int currentTime) => completionTime = currentTime;
    }
}
