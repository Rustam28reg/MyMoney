#include <iostream>
#include "HederFile.h"

using namespace std;

int main()
{
	int len{30}, index{}, choice1{}, num{};
	char choice{};
	list* doList = new list[len]{};

	while (true)
	{
		cout
			<< "1. Add case" << endl
			<< "2. Delete case" << endl
			<< "3. Edit Case" << endl
			<< "4. Find a case " << endl
			<< "5. View to-do list " << endl
			<< "Enter selection by number: "; cin >> choice;
		cin.ignore();

		num = checking(choice);

		switch (num)
		{
		case 1:
			system("cls");
			createList(doList, index);
			index++;
			break;
		case 2:
			system("cls");
			showAllList(doList, index);
			cout << "Enter the number of the case to be deleted - "; cin >> choice1;
			deleteCase(doList, choice1 - 1, len);
			index--;
			break;
		case 3:
			system("cls");
			showAllList(doList, len);
			cout << "Enter the number of the case to be changed - "; cin >> choice1;
			cin.ignore();
			changeList(doList, choice1);
			break;
		case 4:
			system("cls");
			caseSearch(doList);
			break;
		case 5:
			showAllList(doList, index);
			break;
		default:
			system("cls");
			cout << "Input Error! Enter a number from 1 to 10" << endl;
			cout << "\n";
			break;
		}
	}

	return 0;
}

