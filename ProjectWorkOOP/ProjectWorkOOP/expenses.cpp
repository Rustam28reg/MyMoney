#include "expenses.h"

Expenses::Expenses() = default;
Expenses::Expenses(string& _time, string& sum, string& purpose, string _date)
{
	this->_date = _date;
	this->fullTime = _time;
	this->sum = sum;
	this->purpose = purpose;
}
Expenses::~Expenses() {}

string Expenses::getDate()const
{
	return this->_date;
}
string Expenses::getTime()const
{
	return this->fullTime;
}
string Expenses::getSum()const
{
	return this->sum;
}
string Expenses::getPurpose()const
{
	return this->purpose;
}

void Expenses::setDate(string _date)
{
	this->_date = _date;
}
void Expenses::setTime(string _food)
{
	this->fullTime = _food;
}
void Expenses::setSum(string _health)
{
	this->sum = _health;
}
void Expenses::setPurpose(string sport)
{
	this->purpose = sport;
}


ostream& operator <<(ostream& os, const Expenses& obj)
{
	os << "Time - " << obj.fullTime << endl
		<< "Sum - " << obj.sum << endl
		<< "Purpose - " << obj.purpose << endl;	

	return os;
}



