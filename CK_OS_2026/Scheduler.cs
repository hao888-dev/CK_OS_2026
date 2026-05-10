using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class Process
    {
        // các thuộc tính của tiến trình
        private string id;
        private int arrivalTime;
        private int burstTime;
        private int priority;
        private int remainingTime;

        // biến để lưu trữ kết quả sau khi thực hiện thuật toán
        private int waitingTime;
        private int turnaroundTime;
        private int completionTime;
        private int responseTime;


        // constructor
        public Process(string id, int arrivalTime, int burstTime, int priority = 0) // nếu không có priority thì mặc định là 0
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.priority = priority;

            this.remainingTime = burstTime; // ban đầu remaining time bằng burst time, sau đó remaining time sẽ giảm dần khi tiến trình được thực hiện
        }

        // getter và setter
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        public int BurstTime
        {
            get { return burstTime; }
            set { burstTime = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public int RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; }
        }

        public int WaitingTime
        {
            get { return waitingTime; }
            set { waitingTime = value; }
        }

        public int TurnaroundTime
        {
            get { return turnaroundTime; }
            set { turnaroundTime = value; }
        }

        public int CompletionTime
        {
            get { return completionTime; }
            set { completionTime = value; }
        }

        public int ResponseTime
        {
            get { return responseTime; }
            set { responseTime = value; }
        }

        // phương thức tính toán chung vì tất cả các thuật toán đều dùng Turnaround Time = Completion Time - Arrival Time, Waiting Time = Turnaround Time - Burst Time
        public void CalculateTimes()
        {
            turnaroundTime = completionTime - arrivalTime;
            waitingTime = turnaroundTime - burstTime;
        }
    }

    public class Scheduler
    {
        protected List<Process> processes; // danh sách các tiến trình để thực hiện thuật toán, dùng protected để các lớp con có thể truy cập và thực hiện thuật toán trên danh sách này

        // constructor
        public Scheduler(List<Process> processes)
        {
            this.processes = processes;
        }

        /*
            Các thuật toán FCFS, SJF, RR, Priority...
            sẽ kế thừa lớp Scheduler và override phương thức Run().

            Trong hàm Run():
            - Thực hiện thuật toán scheduling
            - Tính Completion Time
            - Tính Response Time (nếu cần)
            - Gọi CalculateTimes() cho từng process
              để tính Waiting Time và Turnaround Time

            Ví dụ:

            public class FCFSScheduler : Scheduler
            {
                public FCFSScheduler(List<Process> processes)
                    : base(processes)
                {

                }

                public override void Run()
                {
                    // code FCFS ở đây nhé
                }
            }

            => Tức là mấy ông tách ra một file FCFS.cs để code giao diện cho WinForms, 1 file FCFSScheduler để code thuật toán
        */

        public virtual void Run() // cho phép các class con có thể ghi đè, ở đây để trống vì class cha không biết các thuật toán chạy cụ thể ra sao
        {
            // phương thức sẽ được override ở các thuật toán cụ thể
        }

        /*
            Các thuật toán khác như:
            - FCFS
            - SJF
            - Round Robin
            - Priority

            sẽ kế thừa Scheduler và override phương thức Run().

            Điểm khác nhau chủ yếu:
            - cách chọn process
            - cách sắp xếp process

            Công thức tính:
            - Waiting Time
            - Turnaround Time
            - Response Time

            vẫn giống nhau.
        */

    }
}
