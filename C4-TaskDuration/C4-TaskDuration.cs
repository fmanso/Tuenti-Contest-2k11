using System;
using System.Collections.Generic;
using System.IO;

namespace C4_TaskDuration
{
    public class Task
    {
        public int Id;
        public int Duration;
        public int[] Dependencies;
    }


    class Program
    {
        enum ReadingState
        {
            NumberOfTasks,
            TaskDuration,
            TaskDependencies
        }

        static void Main()
        {
            var dictionary = ReadFile("in");
            var line = Console.ReadLine();
            if (line != null)
            {
                var taskIds = line.Split(',');
                foreach (var strId in taskIds)
                {
                    Console.WriteLine(String.Format("{0} {1}", strId, Time(Int32.Parse(strId), dictionary)));
                }
            }
        }

        static int Time(int taskId, Dictionary<int, Task> tasks)
        {
            Task t = tasks[taskId];
            if (t.Dependencies == null || t.Dependencies.Length == 0) return t.Duration;


            int maxDuration = 0;
            foreach (var dependency in t.Dependencies)
            {
                int aux = Time(dependency, tasks) + t.Duration;
                if (aux > maxDuration) maxDuration = aux;                    
            }
            return maxDuration;
        }

        static Dictionary<Int32, Task> ReadFile(string fileName)
        {
            ReadingState state = ReadingState.NumberOfTasks;
            var tasks = new Dictionary<Int32, Task>();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while (((line = reader.ReadLine()) != null))
                {
                    if (String.IsNullOrEmpty(line)) continue;                    
                    if (line.Equals("#Number of tasks")) { state = ReadingState.NumberOfTasks; continue; }
                    if (line.Equals("#Task duration")) { state = ReadingState.TaskDuration; continue; }
                    if (line.Equals("#Task dependencies")) {state = ReadingState.TaskDependencies; continue;}
                    string[] strings;
                    int key;
                    switch (state)
                    {
                        case ReadingState.NumberOfTasks:
                            break;
                        case ReadingState.TaskDuration:
                            strings = line.Split(',');
                            key = Int32.Parse(strings[0]);
                            tasks.Add(key, new Task { Id = key, Duration = Int32.Parse(strings[1])});
                            break;
                        case ReadingState.TaskDependencies:
                            strings = line.Split(',');
                            key = Int32.Parse(strings[0]);
                            Task task = tasks[key];
                            task.Dependencies = new int[strings.Length - 1];
                            for (var i = 1; i < strings.Length; i++ )
                            {
                                task.Dependencies[i - 1] = Int32.Parse(strings[i]);
                            }
                            break;
                    }

                }
            }

            return tasks;
        }
    }
}
