using System;

public class Ellips
{
    public double a { get; set; }
    public double b { get; set; }

    public Ellips(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public void Print()
    {
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }

    public virtual double Sqr()
    {
        return Math.PI * a * b;
    }

    public double Ex()
    {
        return Math.Pow(b, 2) / Math.Pow(a, 2);
    }
}

public class Krug : Ellips
{
    public Krug(double r) : base(r, r)
    {
    }

    public override double Sqr()
    {
        return Math.PI * Math.Pow(a, 2);
    }

    public double Leng()
    {
        return 2 * Math.PI * a;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random(); // Додано оголошення Random

        // Опис змінної батьківського класу
        Ellips ellipse;

        // Цикл з трьох ітерацій випадковим чином отримувати значення
        for (int i = 0; i < 3; i++)
        {
            // Залежно від умови задачі привласнити змінній, що оголошена, об'єкт або батьківського класу або
            // дочірнього класу
            double a = random.NextDouble() * 10; // Використовуємо random для отримання випадкових значень
            double b = random.NextDouble() * 10;
            if (b >= a)
            {
                ellipse = new Ellips(a, b);
            }
            else
            {
                ellipse = new Krug(a);
            }

            // Застосувати до створеного об'єкту віртуальні методи
            ellipse.Print();
            double sqrResult = ellipse.Sqr(); // Потрібно зберегти результати виклику методів
            double exResult = ellipse.Ex();

            // Якщо в дочірньому класі є власні методи, то потрібно створити ще один об'єкт
            // дочірнього класу і застосувати до нього власні методи
            if (ellipse is Krug)
            {
                Krug krug = (Krug)ellipse;
                double lengResult = krug.Leng();
            }
        }
    }
}
