#include <iostream>;
#include "HederFile.h"
using namespace std;

int	checking(char num)
{
	int num1{};
	if (int(num) < 48 || int(num) > 57)
	{
		cout << "It is not a number" << endl;
		cin.ignore();
		return 0;
	}
	else
	{
		num1 = int(num) - 48;
		return num1;
	}
}

void createList(list* _doList, int i)
{
	int priorChek{};
	cout << "Enter title - ";
	cin.getline(_doList[i].name, 30);

	cout << "Enter content - ";
	cin.getline(_doList[i].content, 200);

	cout << "Enter priority 1 - 3: ";
	cin >> _doList[i].priority;

	priorChek =  checking(_doList[i].priority);

	if (priorChek == 0)
	{
		return createList(_doList, i);
	}

	while (_doList[i].priority < 1 && _doList[i].priority > 3)
	{
		cout << "Input error! Enter number 1 - 3. \nPress 4 to exit" << endl;
		cout << "Enter prioriry - "; cin >> _doList[i].priority; 

			if (_doList[i].priority == 4)
			{
				break;
			}
	}

	cout << "Enter day \" 01 \" -  ";
	cin >> _doList[i].dateTime.day;

	cout << "Enter month \" 05 \" -  ";
	cin >> _doList[i].dateTime.month;

	cout << "Enter year \" 1997 \" -  ";
	cin >> _doList[i].dateTime.year;

	cout << "Enter hour \" 05 \" -  ";
	cin >> _doList[i].dateTime.hour;

	cout << "Enter minute \" 15 \" -  ";
	cin >> _doList[i].dateTime.minute;

	system("cls");
}

void showAllList(list* _dolist, int _len)
{
	for (size_t i = 0; i < _len; i++)
	{
		cout << "Case ¹ " << (i + 1) << endl;
		cout << "Date: " << _dolist[i].dateTime.day << '.'
			<< _dolist[i].dateTime.month << '.'
			<< _dolist[i].dateTime.year << "\t"
			<< "Time: " << _dolist[i].dateTime.hour << ":"
			<< _dolist[i].dateTime.minute << endl;
		cout << "Title - " << _dolist[i].name << endl;
		cout << "Content: " << _dolist[i].content << endl;
		cout << "Priority - " << _dolist[i].priority << endl;
		cout << "\n";
	}

}

void showCase(list* _dolist, int i)
{
	cout << "Case ¹ " << (i + 1) << endl;
	cout << "Date: " << _dolist[i].dateTime.day << '.'
		<< _dolist[i].dateTime.month << '.'
		<< _dolist[i].dateTime.year << "\t"
		<< "Time: " << _dolist[i].dateTime.hour << ":"
		<< _dolist[i].dateTime.minute << endl;
	cout << "Title - " << _dolist[i].name << endl;
	cout << "Content: " << _dolist[i].content << endl;
	cout << "Priority - " << _dolist[i].priority << endl;
	cout << "\n";
}

void deleteCase(list* _dolist, int _choice, int _len)
{
	int k{};
	list* _dolist2 = new list[_len]{};
	if (_choice == 0)
	{
		for (size_t i = 1; i < _len; i++)
		{
			_dolist2[k] = _dolist[i];
			k++;
		}
		for (size_t i = 0; i < _len; i++)
		{
			_dolist[i] = _dolist2[i];
		}
	}
	else
	{
		for (size_t i = 0; i < _choice; i++)
		{
			_dolist2[k] = _dolist[i];
			k++;
		}
		for (size_t i = _choice + 1; i < _len; i++)
		{
			_dolist2[k] = _dolist[i];
			k++;
		}
		for (size_t i = 0; i < _len - 1; i++)
		{
			_dolist[i] = _dolist2[i];
		}
	}

}

void changeList(list* _doList, int i)
{
	i--;
	cout << "Enter title - ";
	cin.getline(_doList[i].name, 30);

	cout << "Enter content - ";
	cin.getline(_doList[i].content, 200);

	cout << "Enter priority 1 - 3: ";
	cin >> _doList[i].priority;

	while (_doList[i].priority < 1 && _doList[i].priority > 3)
	{
		cout << "Input error! Enter number 1 - 3. \nPress 4 to exit" << endl;
		cout << "Enter choice - "; cin >> _doList[i].priority; \

			if (_doList[i].priority == 4)
			{
				break;
			}
	}

	cout << "Enter day -  ";
	cin >> _doList[i].dateTime.day;

	cout << "Enter month -  ";
	cin >> _doList[i].dateTime.month;

	cout << "Enter year -  ";
	cin >> _doList[i].dateTime.year;

	cout << "Enter hour -  ";
	cin >> _doList[i].dateTime.hour;

	cout << "Enter minute -  ";
	cin >> _doList[i].dateTime.minute;


}

void caseSearch(list* _dolist)
{
	Time dataTime1{}, dataTime2{};

	while (true)
	{
		int index{}, num{}, num1{}, k{};
		char choice{};
		char* name = new char[30] {};
		char* content = new char[30] {};
		cout << "Case search by: " << endl
			<< "1. Name " << endl
			<< "2. Priority " << endl
			<< "3. Content " << endl
			<< "4. Date and time " << endl
			<< "5. Back to main menu" << endl
			<< "Enter choice - "; cin >> choice;

		cin.ignore();
		system("cls");

		num1 = checking(choice);


		if (int(choice) < 49 || int(choice) > 53)
		{
			cout << "Input Error, please enter a number from 1 to 5" << endl;
			continue;
		}



		switch (num1)
		{
		case 1:
			cout << "Enter case name - "; cin.getline(name, 30);

			for (size_t i = 0; i < 30; i++)
			{
				for (size_t j = 0; j < 30; j++)
				{
					if (_dolist[i].name[j] == name[j])
					{
						index++;
					}
					else
					{
						cout << "Ñase with this name not found" << endl;
						i = 30;
						break;
					}
				}
				if (index == 30)
				{

					showCase(_dolist, i);
					break;
				}
			}
			break;
		case 2:
			cout << "Enter priority level from 1 to 3 - "; cin >> num;
			if (num < 1 || num > 3)
			{
				cout << "Input Error";
				continue;
			}
			for (size_t i = 0; i < 30; i++)
			{
				if (_dolist[i].priority == num)
				{
					showCase(_dolist, i);
				}
				else
				{
					cout << "Case not found" << endl;
					break;
				}
			}
			break;
		case 3:

			cout << "Enter content - "; cin.getline(content, 200);

			while (content[num] != '\0')
			{
				num++;
			}
			for (size_t i = 0; i < 30; i++)
			{
				for (size_t j = 0; j < 200; j++)
				{
					if (content[k] == _dolist[i].content[j] && content[k] != '\0')
					{
						index++;
						k++;
					}
					else
					{
						k = 0;
						if (index == num)
						{
							showCase(_dolist, i);
							return;
						}
						else
						{
							index = 0;
						}
					}

				}
				if (i == 29)
				{
					cout << "Case not found" << endl;
				}
			}
			break;

		case 4:
			
			
			cout << "Enter day - "; cin >> dataTime1.day;
			cout << "Enter month - "; cin >> dataTime1.month;
			cout << "Enter year - "; cin >> dataTime1.year;

			for (size_t i = 0; i < 30; i++)
			{
				if (_dolist[i].dateTime.day == dataTime1.day && _dolist[i].dateTime.month == dataTime1.month && _dolist[i].dateTime.year == dataTime1.year)
				{
					showCase(_dolist, i);
				}
			}
			break;

		case 5:
			return;
		}

	}

}