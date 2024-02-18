#include <iostream>
using namespace std;

//keys
int k1 = 3, k2 = 2;
//алфавит
char alphabet[] = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

//дл нахождения мультипликативной инверсии
int invers(int a)
{
    for (int i = 1; i < 26; i++)
    {
        if ((a * i) % 26 == 1)
            return i;
    }
    return 0;
}

//афинный шифр
//функция зашифровки
string schifr(string s)
{
    int code;
    int num;
    string r;

    for (int i = 0; i < s.length(); i++)
    {
        //с = (p*k1 + k2) mod n
        //p - символ, который в данный момент шифруется
        for (int j = 0; j < 26; j++)
        {
            if (s[i] == alphabet[j])
            {
                num = j;
                continue;
            }
        }

        code = (num * k1 + k2) % 26;

        r = r + alphabet[code];
    }

    return r;
}

string deschifr(string s)
{
    int code;
    int num;
    string r;

    for (int i = 0; i < s.length(); i++)
    {
        //p = ((c - k2) k1^-1) mod n
        //c - символ, который в данный момент дешифруется
        for (int j = 0; j < 26; j++)
        {
            if (s[i] == alphabet[j])
            {
                num = j;
                continue;
            }
        }

        code = ((num - k2)* (invers(k1))) % 26;

        r = r + alphabet[code];
    }

    return r;

}

int main()
{
    // зашифровка: с = (p*k1 + k2) mod n
    // расшифровка: p = ((c - k2) k1^-1) mod n
    string b = "man", s1, s2;

    s1 = schifr(b);
    s2 = deschifr(s1);


    cout << "res schifr " << s1 << endl;
    cout << "res deschifr " << s2 << endl;

}
