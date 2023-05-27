#include <iostream>
#include "Heder.h"
using namespace std;


int main()
{
    int size{};

	while (true)
	{
		cout << "Select field size: " << endl
			<< "1. 4x4" << endl
			<< "2. 6x6" << endl;
		cout << "Enter choice - "; cin >> size;
		system("cls");

		if (size < 1 || size > 2)
		{
			system("cls");
			cout << "Input Error. Enter 1 or 2" << endl;
			continue;
		}
		else
		{
			game(size);
		}
	}





}


