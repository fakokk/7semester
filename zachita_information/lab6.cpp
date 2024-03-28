#include <iostream>
#include <cmath>
#include <random>

using namespace std;

//вычисление обратного числа по модулю для вычисления d
int inv(int a, int n) 
{
    if (a % n != 0) 
    {
        int result = 1;

        while (true) 
        {
            if ((result * a) % n == 1) 
            {
                return result;
            }
            result += 1;
        }
    }
    else {
        return -1;
    }
}

//функция нахождения нод двух чисел
int gcd_func(int a, int b)
{
    if (a < b) 
    {
        swap(a, b);
    }
    while (a % b != 0) 
    {
        a = a % b;
        swap(a, b);
    }
    return b;
}

//зашифровка сообщения
int zachifr(int message, int pk[])
{
    int e = pk[0];
    int n = pk[1];

    return fmod((pow(message, e)), n);
}

//дешифрование
int dechifr(int message, int sk[]) 
{
    int d = sk[0];
    int n = sk[1];

    return fmod((pow(message, d)), n);
}



int main() 
{

    setlocale(LC_ALL, "Russian");

    cout << "RSA" << endl;

    int p = 13;
    int q = 17;

    int n = p * q;

    int eiler = (q - 1) * (p - 1);

    //генерируем е рандомно от нуля до n 
    int e = rand() % (n);

    //находим нод
    int gcd = gcd_func(e, eiler);

    
    while (gcd != 1) 
    {
        //e = rand() % (n);
        gcd = gcd_func(e, eiler);
    }

    //////второй ключ

    int d = inv(e, eiler);
    if (d == -1) 
    {
        cout << "error" << endl;
        return 0;
    }

    //полученные ключи
    int pk[] = { e, n };
    int sk[] = { d, n };

    cout << "Ключи: " << endl;

    cout << "PK = [" << pk[0] << ", " << pk[1] << "];" << endl;
    cout << "SK = [" << sk[0] << ", " << sk[1] << "];" << endl;

    int message = 113;
    cout << "Исходное сообщение: " << message << endl;

    int enc = zachifr(message, pk);
    cout << "Зашифрованное сообщение: " << enc << endl;

    int dec = dechifr(enc, sk);
    cout << "Раcшифрованное сообщение: " << dec << endl;

    return 0;
}
