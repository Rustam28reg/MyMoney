#pragma once
#include <iostream>
using namespace std;

struct Balance
{
private:
	int left{};
	int right{};
public:

	Balance();
	Balance(int left, int right);
	~Balance();

	Balance& operator +(const Balance& num);
	Balance& operator -(const Balance& num);

	Balance& operator +=(const Balance* num);
	Balance& operator -=(const Balance* num);	
	Balance& operator =(const string& strBalance);

	friend ostream& operator<<(ostream& os, const Balance& obj);
	friend istream& operator>>(istream& os, Balance& obj);


	bool operator<=(const Balance& other); 

	Balance createBalance(string balance);

	int getLeft()const;
	int getRight()const;

	void setLeft(int num);
	void setRight(int num);


};