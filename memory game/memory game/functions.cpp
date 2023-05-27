#include <ctime>;
#include <iostream>;
using namespace std;

void game(int _size)
{
	int horizontal1{}, vertical1{}, horizontal2{}, vertical2{}, len{}, count{}, randNum{}, num{}, start{}, exit{}, count1{}, time1{}, trying{};
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


	while (true)
	{
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

		cout << "1. Start game" << endl
			<< "2. Back to main menu" << endl
			<< "Enter choice - "; cin >> start;
		system("cls");
		time1 = time(0);

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
					if (arr2[i][j] != 0)
					{
						count1++;
					}
				}
				cout << endl;
				cout << endl;
				if (count1 == (len * len))
				{
					cout << "You win!!!" << endl;
					cout << "Spent time - " << time(0) - time1 << endl;
					cout << "Spent trying - " << trying << endl;
					cout << endl << endl;
					break;
				}
			}

			cout << "Continue enter - 1" << endl
				<< "Look at the block enter - 2" << endl
				<< "If you want to exit enter - 3" << endl
				<< "Enter choice - "; cin >> exit;
			system("cls");

			if (exit == 3)
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
			while (true)
			{
				cout << "Enter vertical value - "; cin >> vertical1;
				cout << "Enter horizontal value - "; cin >> horizontal1;
				if (arr2[vertical1 - 1][horizontal1 - 1] != 0)
				{
					cout << "You have already opened this cell" << endl << endl;
				}
				else
				{
					break;
				}

			}
			cout << "Enter the coordinates of the second number - " << arr1[vertical1 - 1][horizontal1 - 1] << endl;
			cout << "Enter vertical value - "; cin >> vertical2;
			cout << "Enter horizontal value - "; cin >> horizontal2;

			system("cls");

			if (arr1[vertical1 - 1][horizontal1 - 1] == arr1[vertical2 - 1][horizontal2 - 1])
			{
				arr2[vertical1 - 1][horizontal1 - 1] = arr1[vertical1 - 1][horizontal1 - 1];
				arr2[vertical2 - 1][horizontal2 - 1] = arr1[vertical2 - 1][horizontal2 - 1];
				trying++;

			}
			else
			{
				cout << "Didn't guess try again" << endl << endl;				
				trying++;

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