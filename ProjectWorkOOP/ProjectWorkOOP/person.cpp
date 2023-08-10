#include "person.h"
#include <fstream>
#include <json.hpp>
using namespace nlohmann;

Person::Person() = default;
Person::Person(std::string name, std::string surName, std::string day, std::string monh, std::string year)
{
    this->name = name;
    this->surName = surName;
    this->day = day;
    this->monh = monh;
    this->year = year;
}

Person::~Person(){}

string Person::getName() const
{
    return this->name;
}
string Person::getSurName() const
{
    return this->surName;
}
string Person::getday() const
{
    return this->day;
}
string Person::getMonh() const
{
    return this->monh;
}
string Person::getYear() const
{
    return this->year;
}

void Person::setName(string& variable)
{
     this->name = variable;
}
void Person::setSurName(string& variable)
{
    this->surName = variable;
}
void Person::setday(string& variable)
{
    this->day = variable;
}
void Person::setMonh(string& variable)
{
    this->monh = variable;
}
void Person::setYear(string& variable)
{
    this->year = variable;
}

ostream& operator<<(ostream& os, const Person& obj)
{
    os << "User name - " << obj.name << endl
        << "User surname - " << obj.surName << endl
        << "Day - " << obj.day << endl
        << "Month - " << obj.monh << endl
        << "Full wallet balance: " << obj.year << endl;

    return os;
}

Person* createPerson(string Wallet_index)
{
    string name{}, surName{}, day{}, month{}, year{};

    cout << "Create person: " << endl;
    cout << "Enter Name - "; cin >> name;
    checkValue(name, regex("^[A-ZА-Я][a-zа-я ]*$"));
    cout << "Enter Surname - "; cin >> surName;
    checkValue(surName, regex("^[A-ZА-Я][a-zа-я ]*$"));

    cout << endl << endl;
    cout << "Date of Birth:" << endl;

    cout << "Enter day \"DD\" - "; cin >> day;
    checkValue(day, regex("0[0-9]{0,1}|1[0-9]{0,1}|2[0-9]{0,1}|3[0-1]{0,1}"));

    cout << "Enter monh \"MM\" - "; cin >> month;
    checkValue(month, regex("0[0-9]{0,1}|1[0-2]{0,1}"));

    cout << "Enter year \"YYYY\" - "; cin >> year;
    checkValue(year, regex("19[0-9][0-9]|200[0-5]"), "Border year 2005 ");

    Person* user = new Person(name, surName, day, month, year);

    // Запись в файл json
    json person;
    person["UserName"] = user->getName();
    person["UserSurname"] = user->getSurName();
    person["UserDay"] = user->getday();
    person["UserMonth"] = user->getMonh();
    person["UserYear"] = user->getYear();

    string fileName("user-" + Wallet_index + ".json");

    ofstream outputFile(fileName);
    if (!outputFile.is_open()) {
        std::cout << "Unable to open the file for writing." << std::endl;
    }
    outputFile << person.dump(4);
    outputFile.close();

    return user;

}

void Person::deleteUser(string wallet_count)
{
    this->name = "";
    this->surName = "";
    this->day = "";
    this->monh = "";
    this->year = "";

    json person;
    person["UserName"] = this->name;
    person["UserSurname"] = this->surName;
    person["UserDay"] = this->day;
    person["UserMonth"] = this->monh = "";
    person["UserYear"] = this->year = "";

    string fileName("user-" + wallet_count + ".json");

    ofstream outputFile(fileName);
    if (!outputFile.is_open()) {
        std::cout << "Unable to open the file for writing." << std::endl;
    }
    outputFile << person.dump(4);
    outputFile.close();
}
