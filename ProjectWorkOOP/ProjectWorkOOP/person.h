#pragma once
#include <iostream>
#include <string>
#include "myFunctions.h"
using namespace std;

class Person
{
private:
    string name{};
    string surName{};
    string day{};
    string monh{};
    string year{};
public:
    Person();
    Person(string name, string surName, string day, string monh, string year);

    ~Person();

    string getName()const;
    string getSurName()const;
    string getday()const;
    string getMonh()const;
    string getYear()const;

    void setName(string& variable);
    void setSurName(string& variable);
    void setday(string& variable);
    void setMonh(string& variable);
    void setYear(string& variable);

    friend ostream& operator<<(ostream& os, const Person& obj);

    void deleteUser(string wallet_count);

};

Person* createPerson(string Wallet_index);
