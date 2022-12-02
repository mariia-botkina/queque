using System;

internal class Program
{
    private static void Main(string[] args)
    {
        
            static void Menu() //меню
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Напечатать список.");
            Console.WriteLine("2.Добавить объект.");
            Console.WriteLine("3.Удалить объект.");
            Console.WriteLine("Для запуска действия введите число без дополнительных символов.");
            Console.WriteLine("Для выхода введите 'exit' без кавычек.");
        }
        static void GetAnswer(Queue array) //процедура получения данных от пользователя
        {
            Console.Write("Введите номер команды: ");
            string? userline = Console.ReadLine();
            while (userline == null) //проверка, что строка не пустая
            {
                Console.WriteLine("Ошибка. Введена пустая строка."); //вывод ошибки
                Console.WriteLine("Введите команду еще раз: ");
                userline = Console.ReadLine(); //повторный ввод данных пользователем
            }
            if (userline.ToLower() != "exit")
            {
                if (userline == "1") 
                {
                    array.Print(); //процедура печати очереди
                }
                else if (userline == "2")
                {
                    array.Enqueue(); //процедура добавления объекта в очередь
                }
                else if (userline == "3")
                {
                    array.Dequeue(); //процедура удаления объекта из очереди
                }
                else Console.WriteLine("Введена неизвестная команда."); 
                GetAnswer(array); //повторный запуск считывания ввода пользователя
            }
            else //пользователь ввел 'exit'
            {
                Console.WriteLine("Вы вышли из программы."); //выход из программы
            }
        }

        Queue queue = new Queue(); //инициализация очереди
        Menu(); //вывод меню
        GetAnswer(queue);
        Console.ReadKey(); //задержка экрана
        
    }

    class Queue //класс "очередь"
    {
        const int len = 4; //длина класса, константа
        int?[] info = new int?[Queue.len]; //массив длины len

        public int? head; //голова очереди
        public int? tail; // хвост очереди

        public void Enqueue() //процедура добавления элемента в очередь
        {
            int GetData() //функция считывания нового элемента
            {
                Console.Write("Введите новый элемент: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }

            if (head == null) //если нет головы, то заполняем
            {
                head = 0;
                tail = 0;
                info[head] = GetData();
            }
            else //голова заполнена
            {
                if (tail < Queue.len - 1) tail++; // индекс хвоста, куда будем добавлять элемент
                else tail = 0; //если дошли до конца списка, то переходим в начало
                if (tail == head) //хвост совпал с головой
                {
                    Console.WriteLine("Ошибка. Очередь полна."); 
                    if (tail == 0) tail = Queue.len - 1; //возвращаем исходное значение хвоста
                    else tail--;
                }
                else //хвост не совпал с головой
                {
                    info[tail] = GetData(); //заполняем ячейку данными
                }
            }
        }
        
        public void Dequeue() //удаление элемента из очереди
        {
            if (head == null) Console.WriteLine("Ошибка. Очередь пуста."); //нет элементов – очередь пуста
            else
            {
                if (head != tail) //не один элемент в очереди
                {
                    info[head] = null; //обнуляем данные головы
                    if (head < Queue.len - 1) head++; //обновляем индекс головы
                    else head = 0;
                }
                else //один элемент в очереди
                {
                    info[head] = null; //обнуляем все, список пуст
                    head = null;
                    tail = null;
                }
            }
            
        }
        public void Print() //печать очереди
        {
            if (head == null) Console.WriteLine("Ошибка. Очередь пуста.");
            else //очередь не пуста
            {
                Console.Write("Cписок:");
                int? printed = head;

                while (printed != tail)
                {
                    Console.Write($" {info[printed]}");
                    if (printed < Queue.len - 1) printed++; //обновляем индекс элемента
                    else printed = 0;
                }
                Console.WriteLine($" {info[printed]}"); //дописываем хвост
            }
        }
    }
}
