#include <iostream>
#include <string.h>

using namespace std;

//русский алфавит
//индексы от нуля до 33
char alphabet[33] =  {'а', 'б', 'в', 'г', 'д', 'е', 'ё',
                      'ж', 'з', 'и', 'й', 'к', 'л', 'м', 
                      'н', 'о', 'п', 'р', 'с', 'т', 'у', 
                      'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                      'ы', 'ь', 'э', 'ю', 'я'};

//функция возвращает индекс элемента
int return_index(char ch)
{
    for (int i = 0; i < 33; i++)
    {
        //if (ch == '\0')
        //    continue;
        if (ch == alphabet[i])
            return i;
    }
    return 404;
}

//функция для составления строки кода из слова кода
string return_correct_code(string S_start, string S_code)
{
    //строка результата
    string res;

    //текущий символ
    char chi;

    //если кодированное слово закончилось 
    //то мы должны проходиться с первого символа
    int counter = 0;

    int Start_size = S_start.size();
    int Code_size = S_code.size();

    for (int i = 0; i < Start_size; i++)
    {
        if (S_start[i] == ' ')
        {
            chi = ' ';
        }
        if (counter == 0)
        {
            chi = S_code[0];
            counter++;
        }
        else
        if (counter < Code_size)
        {
            chi = S_code[counter];
            counter++;
        }
        else
        if (counter > Code_size)
        {
            counter = 0;
            chi = '\0';
            //continue;
        }
        else
        if (counter == Code_size)
        {
            chi = S_code[i];
            counter = 0;       
        }

        res = res + chi;
    }

    res.erase(std::remove(res.begin(), res.end(), '\0'), res.end());
    return res;

}

//цезарь
string cezar(int k, bool shift, string S)
{
    //k - сдвиг на k 
    //shift - сдвиг влево (0), сдвиг вправо (1)
    //S - строка на вход
    //S_res - строка после шифрования
    string S_res;
    char chi;

    for (int i = 0; i < S.size(); i++)
    {
        if (S[i] == ' ')
        {
            chi = ' ';
        }
        else
        {
            for (int j = 0; j < 33; j++)
            {
                //сдвиг вправо
                if ((S[i] == alphabet[j]) and (shift == true))
                {
                    chi = alphabet[j + k];
                    //break;
                }
                else
                    //сдвиг влево
                    if ((S[i] == alphabet[j]) and (shift == false))
                    {
                        chi = alphabet[j - k];
                        //break;
                    }
                if (j == 33)
                {
                    continue;
                }

                continue;
            }
        }

        S_res = S_res + chi;
        //cout << "Результат: " << S_res << endl;
    }
    return S_res;
}
//виженер
string vizhener(string S_start, string S_code)
{
    // формула
    // сj = (mj + kj) mod n
    // текущий символ = (символ из строки + символ из шифра) % кол-во символов алфавита
    // mod работает в случае если символы имеют большой номер, чтобы не переваливаться 
    // за пределы алфавита (j <= 33)

    // string S_start - строка начальная
    // string S_code - строка с кодом

    // рабочая формула:
    // chj = (S_start[j] + S_code[j]) % 33

    string s_rez;
    char chi;   //текущий символ
    int index;  //индекс элемента который получится в результате шифрования
    int a1 = 0, a2 = 0;
    int Start_size = S_start.size();

    for (int i = 0; i < Start_size; i++)
    {
        if (S_start[i] == ' ')
        {
            chi = ' ';
        }
        else
        //if (chi != '\0')
        {
            //return_index(char ch)
            a1 = return_index(S_start[i]);
            a2 = return_index(S_code[i]);

            index = (a1 + a2) % 33;
            cout << index << " - index; " << a1 << " - a1; " << a2 << " - a2" << endl;

            chi = alphabet[index];
            cout << chi << " - chi;" << endl << endl;
            index = 0;
        }

        s_rez = s_rez + chi;
    }

    return s_rez;
}

int main()
{
    setlocale(LC_ALL, "Russian");

    cout << "Первая лабораторная работа." << endl << endl;
    cout << "Шифр Цезаря." << endl << endl;
    //в Цезаре а=г, б=д и тд

    //сдвиг, для Цезаря k = 3
    int k = 3;
    //будем считать что:
    // 
    //shift = false - сдвиг влево
    //shift = true - сдвиг вправо
    // 
    //для Цезаря true
    bool shift = true; 

    //cout << "Введите строку:" << endl;
    //cin >> S;

    string S1 = "мама мыла раму";
    string S2 = "пгпг пюог угпц";

    string S_res_cezar;
    
    S_res_cezar = cezar(k, shift, S1);

    cout << "Строка для шифровки: " << S1 << endl;
    cout << "Результат Цезарь шифрование: " << S_res_cezar << endl;
    cout << endl;

    //сдвиг влево - для расшифровки строки
    shift = false;
    S_res_cezar = cezar(k, shift, S2);

    cout << "Строка для расшифровки: " << S2 << endl;
    cout << "Результат Цезарь расшифровка: " << S_res_cezar << endl;
    cout << endl;
    
    //------------------------------------------------------------------

    cout << "Шифр Виженера." << endl << endl;
    //vizhener(string S_start, string S_code)

    string S3 = "метод прямого перебора";
    //string S4 = "мама мама мама мама мама";
    //string S4 = "оауяд вмбзпуо вбтавярт";
    string S_code = "выбрать";
    string S_res_vizhener;

    string s_code_v1 = return_correct_code(S3, S_code);
    //string s_code_v2 = return_correct_code(S4, S_code);

    int operation = 0;
    // operation = 0 - проводим зашифровку
    // operation = 1 - проводим расшифровку
    
    S_res_vizhener = vizhener(S3, s_code_v1);

    cout << "Кодовое слово: " << s_code_v1 << endl;
    cout << "Строка для шифровки: " << S3 << endl;
    cout << "Результат Виженер шифрование: " << S_res_vizhener << endl;
    cout << endl;

    /*
    S_res_vizhener = vizhener(S4, s_code_v2);

    operation = 1;
    cout << "Кодовое слово: " << s_code_v2 << endl;
    cout << "Строка для расшифровки: " << S4 << endl;
    cout << "Результат Виженер расшифровка: " << S_res_vizhener << endl;
    cout << endl;
    */

}