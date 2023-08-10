#pragma once
#include <iostream>
using namespace std;

class Expenses 
{
private:
	string _date{};
	string fullTime{}; 
	string sum{}; 
	string purpose{}; 
public:

	Expenses();
	Expenses(string& time, string& sum, string& purpose, string _date = "");
	~Expenses();

	string getDate()const;
	string getTime()const;
	string getSum()const;
	string getPurpose()const;

	void setDate(string _date);
	void setTime(string time);
	void setSum(string sum);
	void setPurpose(string purpose);

	friend ostream& operator <<(ostream& os, const Expenses& obj);
};

