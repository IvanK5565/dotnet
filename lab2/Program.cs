class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Студент: Козловський Іван Вікторович");
        Console.WriteLine("Група: 8.1214\n");
        Console.WriteLine("Трикутник:");
        double[,] triangle = { { 0, 0 }, { 1, 0 }, { 1, 1 } };
        ShapeTriangle fe3 = new ShapeTriangle(triangle);
        fe3.Print();

        Console.WriteLine("\nЧотирикутник:");
        double[,] quadrangle = { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 0, 1 } };
        ShapeQuadrangle fe4 = new ShapeQuadrangle(quadrangle);
        fe3.Print();

        Console.WriteLine("\nТетраєдр:");
        double[,] tetrahedron = { { 0, 0, 0 }, { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        ShapeTetrahedron fe4_2 = new ShapeTetrahedron(tetrahedron);
        fe4_2.Print();

        Console.WriteLine("\nКуб:");
        double[,] cube = { { 0, 0, 0 }, { 1, 0, 0 }, { 0, 1, 0 }, { 1, 1, 0 },
                           { 0, 0, 1 }, { 1, 0, 1 }, { 0, 1, 1 }, { 1, 1, 1 }};
        ShapeCube fe8 = new ShapeCube(cube);
        fe8.Print();

        Console.WriteLine("\nКвадратичний трикутник:");
        double[,] triangle6 = { { 0, 0 }, { 4, 0 }, { 2, 3 }, { 1, 1.5 }, { 3, 1.5 }, { 2, 0 } };
        ShapeTriangleQuadratic fe6 = new ShapeTriangleQuadratic(triangle6);
        fe6.Print();    

        Console.WriteLine("\nКвадратичний Тетраєдр:");
        double[,] tetrahedron10 = {
            { 0, 0, 0 }, { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 }, // Вершины
            { 0.5, 0, 0 }, { 0, 0.5, 0 }, { 0, 0, 0.5 }, // Средины рёбер
            { 0.5, 0.5, 0 }, { 0.5, 0, 0.5 }, { 0, 0.5, 0.5 }
        };
        ShapeTetrahedronQuadratic fe10 = new ShapeTetrahedronQuadratic(tetrahedron10);
        fe10.Print();
    }
}

// Абстрактный класс «Функция формы»
abstract class ShapeFunction
{
    protected int Size; // Кількість коефіцієнтів функції форми
    protected int Dim; // Розмірність
    protected double[,] C; // Матриця коефіцієнтів
    protected double[,] X; // Координати вершин СЕ
    protected ShapeFunction()
    {
        Size = Dim = 0;
    }
    protected void SetCoord(int psize, double[,] px)
    {
        Size = psize;
        X = new double[Size, Dim];
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Dim; j++)
                X[i, j] = px[i, j];
        Create();
    }
    protected abstract double ShapeCoeff(int i, int j);
    private bool Solve(double[,] matr, double[] result, double eps = 1.0E-10)
    {
        double coeff;
        for (var i = 0; i < Size - 1; i++)
        {
            if (matr[i, i] < eps)
                continue;
            for (var j = i + 1; j < Size; j++)
            {
                if (Math.Abs(coeff = matr[j, i]) < eps)
                    continue;
                for (var k = i; k < Size + 1; k++)
                    matr[j, k] -= (coeff * matr[i, k] / matr[i, i]);
            }
        }
        if (Math.Abs(matr[Size - 1, Size - 1]) < eps)
            return false;
        result[Size - 1] = matr[Size - 1, Size] / matr[Size - 1, Size - 1];
        for (int k = 0; k < Size - 1; k++)
        {
            int i = Size - k - 2;
            var sum = matr[i, Size];

            for (int j = i + 1; j < Size; j++)
                sum -= result[j] * matr[i, j];
            if (Math.Abs(matr[i, i]) < eps)
                return false;
            result[i] = sum / matr[i, i];
        }
        return true;
    }
    public void Create()
    {
        double[,] A = new double[Size, Size + 1];
        double[] res = new double[Size];
        C = new double[Size, Size];
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                for (int k = 0; k < Size; k++)
                    A[j, k] = ShapeCoeff(j, k);
                A[j, Size] = (i == j) ? 1.0 : 0.0;
            }
            if (!Solve(A, res))
                Console.WriteLine("Bad FE!");
            for (int j = 0; j < Size; j++)
                C[i, j] = res[j];
        }
    }
    public void Print()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
                Console.Write("{0} ", C[i, j]);
            Console.WriteLine();
        }
    }
}


// Функції форми трикутного елемента
class ShapeTriangle : ShapeFunction
{
    public ShapeTriangle()
    {
        Size = 3;
        Dim = 2;
    }
    public ShapeTriangle(double[,] px)
    {
        Size = 3;
        Dim = 2;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double[] s = { 1.0, X[i, 0], X[i, 1] };
        return s[j];
    }
}

// Функції форми чотирикутного елемента
class ShapeQuadrangle : ShapeFunction
{
    public ShapeQuadrangle()
    {
        Size = 4;
        Dim = 2;
    }
    public ShapeQuadrangle(double[,] px)
    {
        Size = 4;
        Dim = 2;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double[] s = { 1.0, X[i, 0], X[i, 1], X[i, 0] * X[i, 1] };
        return s[j];
    }
}

class ShapeTetrahedron : ShapeFunction
{
    public ShapeTetrahedron()
    {
        Size = 4;
        Dim = 3 ;
    }
    public ShapeTetrahedron(double[,] px)
    {
        Size = 4;
        Dim = 3;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double[] s = { 1.0, X[i, 0], X[i, 1], X[i, 2] };
        return s[j];
    }
}

class ShapeCube : ShapeFunction
{
    public ShapeCube()
    {
        Size = 8;
        Dim = 3;
    }
    public ShapeCube(double[,] px)
    {
        Size = 8;
        Dim = 3;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double x = X[i, 0]; // Координата X узла i
        double y = X[i, 1]; // Координата Y узла i
        double z = X[i, 2]; // Координата Z узла i


        double[] s = {
        1.0,  // Свободный член
        x,    // Линейные члены
        y,
        z,
        x * y, // Попарные произведения
        x * z,
        y * z,
        x * y * z // Тройное произведение
    };

        if (j >= s.Length)
            return 0.0; // Предотвращаем выход за границы

        return s[j];
    }
}

class ShapeTriangleQuadratic : ShapeFunction
{
    public ShapeTriangleQuadratic()
    {
        Size = 6;
        Dim = 2;
    }
    public ShapeTriangleQuadratic(double[,] px)
    {
        Size = 6;
        Dim = 2;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double[] s = { 1.0, X[i, 0], X[i, 1], X[i, 1] * X[i,0], X[i, 0]* X[i, 0], X[i, 1]* X[i, 1] };
        return s[j];
    }
}

class ShapeTetrahedronQuadratic : ShapeFunction
{
    public ShapeTetrahedronQuadratic()
    {
        Size = 10;
        Dim = 3;
    }
    public ShapeTetrahedronQuadratic(double[,] px)
    {
        Size = 10;
        Dim = 3;
        SetCoord(Size, px);
    }
    protected override double ShapeCoeff(int i, int j)
    {
        double x = X[i, 0];
        double y = X[i, 1];
        double z = X[i, 2];
        double[] s = { 1.0, x, y, z, x * y, x * z, y * z, x * x, y * y, z * z };
        return s[j];
    }
}