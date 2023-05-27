#include <ctime>;
#include <iostream>;
using namespace std;

void game(int _size)
{
	int horizontal1{}, vertical1{}, horizontal2{}, vertical2{}, len{}, count{}, randNum{}, num{}, start{}, exit{};
	srand(time(0));
	if (_size == 1)
	{
		len = 4;
	}
	else if (_size == 2)
	{
		len = 6;
	}

	int** arr1 = new int* [len] {};
	int** arr2 = new int* [len] {};

	for (size_t i = 0; i < len; i++)
	{
		arr1[i] = new int[len] {};
		arr2[i] = new int[len] {};

	}

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = 0; j < len; j++)
		{
			randNum = rand() % 20 + 1;
			for (size_t l = 0; l < len; l++)
			{
				for (size_t k = 0; k < len; k++)
				{
					if (arr1[l][k] == randNum)
					{
						count++;
					}
				}
			}
			if (num < ((len * len) / 2) && count == 0)
			{
				arr1[i][j] = randNum;
				num++;
				continue;
			}
			if (count == 1)
			{

				arr1[i][j] = randNum;
			}
			else
			{
				j--;

			}
			count = 0;
		}
	}

	cout << "Remember the order of the numbers" << endl << endl;;


	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = 0; j < len; j++)
		{
			cout << arr1[i][j] << "\t";
		}
		cout << endl;
		cout << endl;
	}

	while (true)
	{
		cout << "1. Start game" << endl
			<< "2. Back to main menu" << endl
			<< "Enter choice - "; cin >> start;
		system("cls");

		switch (start)
		{
		case 1:
			while (true)
			{
						
			for (size_t i = 0; i < len; i++)
			{
				for (size_t j = 0; j < len; j++)
				{
					cout << arr2[i][j] << "\t";
				}
				cout << endl;
				cout << endl;
			}

			cout << "If you want to exit enter 0" << endl
				<< "Continue enter 1" << endl
				<< "Look at the block enter 2" << endl
				<< "Enter choice - "; cin >> exit;
			system("cls");

			if (exit == 0)
			{
				break;
			}
			else if(exit == 2)
			{
				for (size_t i = 0; i < len; i++)
				{
					for (size_t j = 0; j < len; j++)
					{
						cout << arr1[i][j] << "\t";
					}
					cout << endl;
					cout << endl;
				}
				cout << "If you want to exit enter 0" << endl
					<< "Continue enter 1" << endl
					<< "Enter choice - "; cin >> exit;
				system("cls");
			}

			cout << "Enter horizontal value - "; cin >> horizontal1;
			cout << "Enter vertical value - "; cin >> vertical1;
			cout << "Enter the coordinates of the second number - " << arr1[vertical1 - 1][horizontal1 - 1] << endl;
			cout << "Enter horizontal value - "; cin >> horizontal2;
			cout << "Enter vertical value - "; cin >> vertical2;

			system("cls");

			if (arr1[vertical1 - 1][horizontal1 - 1] == arr1[vertical2 - 1][horizontal2 - 1])
			{
				arr2[vertical1 - 1][horizontal1 - 1] = arr1[vertical1 - 1][horizontal1 - 1];
				arr2[vertical2 - 1][horizontal2 - 1] = arr1[vertical2 - 1][horizontal2 - 1];

			}
			else
			{
				cout << "Didn't guess try again" << endl << endl;				
			}

			}

			break;
		case 2:
			return;
		default:
			cout << "Input Error! Please Enter number 1 - 3.";
			continue;
		}

	}

}