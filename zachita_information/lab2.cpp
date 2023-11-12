#include <iostream>
#include <list>
#include <bitset>
#include <cstdlib>
#include <random>

using namespace std;

list<int>list1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

list<int>list2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };

//фигулина для рандома
random_device rd;
mt19937 gen(rd());


//по заданному символу возвращает 16 - разрядную последовательность 
//нулей и единиц(строку), являющуюся двоичным представлением кода заданного символа.
string char_to_binary16(char a)
{
    //получаем код элемента
    int ASCII = (int)a;
    //cout << ASCII << endl;
    
    //переводим в двоичный 16-разрядный код
    string binary = "00000000" + bitset<8>(ASCII).to_string();

    return binary;
}

int random(int low, int high)
{
    uniform_int_distribution<> dist(low, high);
    return dist(gen);
}

//функция перемешивания элементов s1
string s1_to_s2(string s1, string s2, int m[33])
{
    char a;
    int j;
    bool g = false;
    //две строки, биту из первого присваиваем рандомное значение во втором
    for (int i = 0; i < 32; i++)
    {
        a = s1[i];
        g = false;

        do
        {
            //рандомно генерируем индекс элемента
            j = random(0, 32);

            //если сюда еще не был помещен бит из s1
            if (s2[j] == 'a')
            {
                //присваиваем текущее значение s1
                //позиция рандомно выбранного элемента
                s2[j] = a;

                

                //флаг, обозначили что этот элемент уже нашел свое место
                g = true;
            }
        } while (g == false);

        //для последующего восстановления последовательности
        m[i] = j;
        //m[j][1] = j;
    }
    return s2;
}

//восстановление s1 по s2
void m2_to_m1(string s1, string s2)
{

}

void S_block()
{

}



int main()
{

    string message = "ЖП";
    string message1, message2, message32bit;
    string message_after_random = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    // По заданной текстовой строке, состоящей из двух символов, возвращает
    // строку, зашифрованную с помощью SP - сети, состоящей из двух P - блоков и промежуточной батареи S - блоков.

    char a = message[0]; //1100.0110//0000.0000.1100.0110//Ж
    char b = message[1]; //1100.1111//0000.0000.1100.1111//П

    message1 = char_to_binary16(a);//Ж
    message2 = char_to_binary16(b);//П

    //конкатенация строк для получения
    //32-разрядной последовательности
    message32bit = message1 + message2;

    //массив соответствия индексов 
    //по нему можно восстановить начальную последовательность
    int m[33];

    //перемешивание элементов, возвращает s2
    cout << "message_after_random: " << s1_to_s2(message32bit, message_after_random, m) << endl;

    for (int i = 0; i < 32; i++)
    {
            cout << m[i] << " ";
    }
    

    //По заданной двухбуквенной строке, зашифрованной с помощью с помощью
    //SP - сети, состоящей из двух P - блоков и промежуточной батареи S - блоков, возвращает строку - оригинал.

}