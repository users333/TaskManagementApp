using System;
using System.Collections.Generic;

namespace TaskManagementApp
{
    class Program
    {
        static List<TaskItem> tasks = new List<TaskItem>();
        static int taskId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nTask Management App");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Show Tasks");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4. Exit");

                Console.Write("Choose option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ShowTasks();
                        break;

                    case "3":
                        CompleteTask();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            TaskItem task = new TaskItem(taskId++, title);
            tasks.Add(task);

            Console.WriteLine("Task added!");
        }

        static void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks.");
                return;
            }

            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "Completed" : "Pending";
                Console.WriteLine($"{task.Id}. {task.Title} - {status}");
            }
        }

        static void CompleteTask()
        {
            Console.Write("Enter task id: ");
            int id = int.Parse(Console.ReadLine());

            var task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task completed!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
    }
}
