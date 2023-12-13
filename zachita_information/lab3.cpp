#include <iostream>
#include <bitset>
//#include

using namespace std;

string message_32, message_P, message_S;

string  mess_p1, mess_p2,   //разбиваем последовательность
        mess_p3, mess_p4,   //по 4 бита
        mess_p5, mess_p6,
        mess_p7, mess_p8;
string sh_char1, sh_char2;  //символы получаемые в конце

int m[8];   //элементы в s-блоке, 10сс числа

//перестановки
int p8[] = { 0, 8, 4, 1,
             10, 2, 5, 9};

int p32[] = { 3, 10, 13, 7, 18, 17, 15, 6,
              8, 11, 14, 16, 9, 21, 27, 31,
              19,29, 5, 24, 25, 12, 23, 26,
              1, 20, 2, 30, 22, 28, 0, 4 };

string char_to_bin(char a)
{
    int ASCII = int(a);
    string binary = "00000000" + bitset<8>(ASCII).to_string();

    return binary;
}

char bin_to_char(string binary)
{
    int value = 0;
    int base = 1;
    int len = binary.length();

    for (int i = len - 1; i >= 0; i--) 
    {
        // If the current bit is 1
        if (binary[i] == '1')
            value += base;
        base = base * 2;
    }

    char a = char(value);
    return a;
}

void message_to_binary_code(string message)
{
    string code1, code2;

    char a = message[0];
    char b = message[1];

    code1 = char_to_bin(a);
    code2 = char_to_bin(b);

    message_32 = code1 + code2;

    //0000.0000.1100.0110.0000.0000.1100.1111
    cout << "message 32 bit: " << message_32 << endl;
}

void binary_code_to_message()
{
    //10101110001010100000001110010000
    string s;
    sh_char1 = message_P.substr(0,16);
    sh_char2 = message_P.substr(16, 16);

    s = bin_to_char(sh_char1) + bin_to_char(sh_char2);
    
    cout << endl<<  "Shifr string:" << bin_to_char(sh_char1) << "." << bin_to_char(sh_char2) << endl << endl;
} 

//шифрующий р-блок
void P_block()
{
    int j;

    for (int i = 0; i < 32; i++)
    {
        //берем индекс из перестановки
        j = p32[i];
        //ставим ему в соответствие бит из s1
        message_P = message_P + message_32[j];
    }

    //0010.0000.1010.1001.0101.1000.0001.0100
    cout << "message after P-block: " << message_P << endl;
}

//p-блок, отвещающий за дешифровку сообщения
void P_block_de()
{
    message_32 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    int j;
    for (int i = 0; i < 32; i++)
    {
        //берем индекс из перестановки
        j = p32[i];
        //ставим ему в соответствие бит из s1
        message_32[j] = message_P[i];
    }

    //0010.0000.1010.1001.0101.1000.0001.0100 - 1 результат
    //
    message_P = message_32;
    cout << "message after P-block: " << message_P;
}

void message_P_to_4bit()
{
    mess_p1 = message_P.substr(0, 4);
    mess_p2 = message_P.substr(4, 4);
    mess_p3 = message_P.substr(8, 4);
    mess_p4 = message_P.substr(12, 4);
    mess_p5 = message_P.substr(16, 4);
    mess_p6 = message_P.substr(20, 4);
    mess_p7 = message_P.substr(24, 4);
    mess_p8 = message_P.substr(28, 4);

    //вывод для проверки правильности разбиения на микро-последовательности
    //cout << "P block: " << mess_p1 << " " << mess_p2 << " " << mess_p3 << " " << mess_p4 << " " << mess_p5 << " " << mess_p6 << " " << mess_p7 << " " << mess_p8;
}

//перевод числа из 2сс в 10сс
int bin_to_dec(string bin)
{
    int a = 0;

    for (int i = 0; i < bin.size(); i++)
    {
        a = a * 2 + (bin[i] - '0');
    }
    
    return a;
}

//перевод числа из 10сс в 2сс
string dec_to_bin(int dec)
{
    int i = 0, a = 0;
    string s, s0;

    for (int temp = 32768; temp > 0; temp = temp / 2)
    {
        if (temp & dec)
        {
            s = s + "1";
        }
        else
        {
            s = s + "0";
        }
    }

    int str_size = s.size() - 4;
    s0 = s.substr(str_size, 4);

    return s0;
}

void S_block()
{
    //каждое число переводится в 10сс
    m[0] = bin_to_dec(mess_p1);//2
    m[1] = bin_to_dec(mess_p2);//0
    m[2] = bin_to_dec(mess_p3);//10
    m[3] = bin_to_dec(mess_p4);//9
    m[4] = bin_to_dec(mess_p5);//5
    m[5] = bin_to_dec(mess_p6);//8
    m[6] = bin_to_dec(mess_p7);//1
    m[7] = bin_to_dec(mess_p8);//4

    int j = 0;
    string s;

    int arr[8];

    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (m[i] == p8[j])
                arr[i] = j;
        };
    }

    //0101.0000.0100.0111.0110.0001.0011.0010
    message_32 = dec_to_bin(arr[0]) + dec_to_bin(arr[1]) + dec_to_bin(arr[2]) + dec_to_bin(arr[3])
        + dec_to_bin(arr[4]) + dec_to_bin(arr[5]) + dec_to_bin(arr[6]) + dec_to_bin(arr[7]);

    cout << "32bit p block: " << message_32 << endl;

}

void S_block_de()
{
    //каждое число переводится в 10сс
    m[0] = bin_to_dec(mess_p1);//2
    m[1] = bin_to_dec(mess_p2);//0
    m[2] = bin_to_dec(mess_p3);//10
    m[3] = bin_to_dec(mess_p4);//9
    m[4] = bin_to_dec(mess_p5);//5
    m[5] = bin_to_dec(mess_p6);//8
    m[6] = bin_to_dec(mess_p7);//1
    m[7] = bin_to_dec(mess_p8);//4

    int j;
    string s;

    int arr[8];

    for (int i = 0; i < 8; i++)
    {
       j = m[i];
       arr[i] = p8[j];
    }

    //0000.1000.0100.0001.1010.0010.0101.1001
    //0 8 4 1 10 2 5 9 - было
    //0010.0000.1010.1001.0101.1000.0001.0100
    //2 0 10 9 5 8 1 4 - стало
    message_P = dec_to_bin(arr[0]) + dec_to_bin(arr[1]) + dec_to_bin(arr[2]) + dec_to_bin(arr[3])
        + dec_to_bin(arr[4]) + dec_to_bin(arr[5]) + dec_to_bin(arr[6]) + dec_to_bin(arr[7]);

    cout << "32bit p block: " << message_P << endl;

}


int main()
{
    //зашифрование сообщения

    string message = "ЖП";

    message_to_binary_code(message);
    P_block();
    message_P_to_4bit();
    S_block();
    message_P.clear();
    P_block();
    binary_code_to_message();
    
    //расшифрование сообщения

    cout << endl << "dechifr: " << endl;

    P_block_de();
    cout << endl;
    message_P_to_4bit();
    S_block_de();
    P_block_de();
    binary_code_to_message();

}
