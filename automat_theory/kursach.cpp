#include <iostream>
#include <regex>
#include <map>

using namespace std;

class Analizator
{
public: 
    //конструкторы
    Analizator() { Input = "default"; };
        
    Analizator(string str1) { ChangeInput(str1); };

    void ChangeInput(string str1) { this->Input = str1; }
    
    // проверяемая строка
    string Input;

    // строка бранных слов
    string BadWord;

    //состояния автомата
    // S - начальное
    // Z - конечное
    enum States {S, A, B, C, Z};

    //текущее состояние, устанавливаем в начальное
    States State = S;

    //регулярка - правило перехода
    regex P1{ "сини" };     // A
    regex P2{ "голубо" };   // B
    regex P3{ "розов" };    // C

    // правило перехода применяемое в данный момент
    regex Reg;

    //переход по состоянием и задание текущего перехода
    void Change_State()
    {
        if (this->State == S)
        {
            this->State = A;
            this->Reg = P1;
        }
        else
        if (this->State == A)
        {
            this->State = B;
            this->Reg = P2;
        }
        else
        if (this->State ==B)
        {
            this->State = C;
            this->Reg = P3;
        }
        else
        if (this->State == C)
        {
            this->State = Z;
        };
    }

    //функция преобразования для печати состояния в консоль+
    string StateToString()
    {
        if (this->State == S) { return "S"; }
        if (this->State == A) { return "A"; }
        if (this->State == B) { return "B"; }
        if (this->State == C) { return "C"; }
        if (this->State == Z) { return "Z"; }
    }

    // std::regex_match() возвращает true, если вся входная строка соответствует шаблону
    // std::regex_search() возвращает true, если часть входной строки соответствует шаблону
    bool proverka_brani()
    {
        // на вход проверяемая строка и текущее regex 
        // выясняем есть ли нарушения 
        // аргументы - строка и текущее правило

        // добавляем номер состояния в котором было обнаружено нарушения
        this->BadWord = this->BadWord + StateToString();
        return regex_search(Input.data(), Reg);
    }

    //счетчик плохих слов
    int count_bad_word = 0;

    //функция которая проверяет все регулярные выражения по тексту
    void Proverka()
    {
        //меняем состояние автомата - значит он сейчас проверяет конкретную регулярку
        for (int i = 0; this->State != Z; i++)
        {
            Change_State();

            if (this->State == Z)
                break;

            cout << "This state: " << StateToString() << endl;

            if (proverka_brani())
                count_bad_word++;

        }
        
        if (count_bad_word != 0)
        {
            cout << "Использовано запрещенных выражений: " << count_bad_word << endl;
            cout << "Нарушения: " << this->BadWord << endl;

        }
        else
        {
            cout << "Запрещенные выражения не были использованы";
        }
    }

    //for (const auto& [city, year] : years) {
    //    std::cout << city << ": " << year << "\n";
    //}

};

//главная программа
int main()
{
    setlocale(LC_ALL, "Russian");

    Analizator Proc = Analizator();

    Proc.ChangeInput("красный оранжевый желтый зеленый синий фиолетовый розовый черный");
    //Proc.ChangeInput("мама мыла раму");
    
    Proc.Proverka();
}
