using System;

internal class Program
{
    private static void Main(string[] args)
    {
        
            static void Menu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Напечатать список.");
            Console.WriteLine("2.Добавить объект.");
            Console.WriteLine("3.Удалить объект.");
            Console.WriteLine("Для запуска действия введите число без дополнительных символов.");
            Console.WriteLine("Для выхода введите 'exit' без кавычек.");
        }
        static void GetAnswer(Queue array)
        {
            Console.Write("Введите номер команды: ");
            string? userline = Console.ReadLine();
            while (userline == null)
            {
                Console.WriteLine("Ошибка. Введена пустая строка.");
                Console.WriteLine("Введите команду еще раз: ");
                userline = Console.ReadLine();
            }
            if (userline.ToLower() != "exit")
            {
                if (userline == "1")
                {
                    array.Print();
                }
                else if (userline == "2")
                {
                    
                    array.Enqueue();
                }
                else if (userline == "3")
                {
                    array.Dequeue();
                }
                else Console.WriteLine("Введена неизвестная команда.");
                GetAnswer(array);
            }
            else
            {
                Console.WriteLine("Вы вышли из программы.");
            }
        }

        Queue queue = new Queue();
        Menu();
        GetAnswer(queue);
        Console.ReadKey();
        
    }

    struct IDK
    {
        public int? index { get; set; }
    }

    class Queue
    {
        const int len = 4;
        int?[] info = new int?[Queue.len];

        public IDK head;
        public IDK tail;

        public void Enqueue()
        {
            int GetData()
            {
                Console.Write("Введите новый элемент: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }

            if (head.index == null)
            {
                head.index = 0;
                info[(int)head.index] = GetData();
                tail.index = 0;
            }
            else
            {
                if (tail.index < Queue.len - 1) tail.index++;
                else tail.index = 0;
                if (tail.index == head.index)
                {
                    Console.WriteLine("Ошибка. Очередь полна.");
                    if (tail.index == 0) tail.index = Queue.len - 1;
                    else tail.index--;
                }
                else
                {
                    info[(int)tail.index] = GetData();
                }
            }
        }
        
        public void Dequeue()
        {
            if (head.index == null) Console.WriteLine("Ошибка. Очередь пуста.");
            else
            {
                if (head.index != tail.index)
                {
                    info[(int)head.index] = null;
                    if (head.index < Queue.len - 1) head.index++;
                    else head.index = 0;
                }
                else
                {
                    info[(int)head.index] = null;
                    head.index = null;
                    tail.index = null;
                }
            }
            
        }
        public void Print()
        {
            if (head.index == null) Console.WriteLine("Ошибка. Очередь пуста.");
            else
            {
                Console.Write("Cписок:");
                int? printed = head.index;


                while (printed != tail.index)
                {
                    Console.Write($" {info[(int)printed]}");
                    if (printed < Queue.len - 1) printed++;
                    else printed = 0;
                }
                Console.WriteLine($" {info[(int)printed]}");

            }
        }
    }
}