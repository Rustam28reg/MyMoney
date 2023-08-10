#include"wallet_space.h";

void wallet_space(Wallet* wallet, int wallet_count)
{
	string cardBalance{}, cardNumber{}, amount{}, category{}, _time{}, choice{};
	string toDay = createDate();
	Balance newBalance{};
	int choice_category{};
	bool key = true;

	while (key)
	{
		cout << "1.Add card." << endl
			<< "2.Add money." << endl
			<< "3.To make a purchase." << endl // сделать покупку
			<< "4.Get wallet information." << endl
			<< "5.Get card information." << endl
			<< "6.Get an expense report." << endl // получить отчет о рассходах
			<< "7. Exit." << endl;
		try
		{
			cout << "Enter your choice - "; cin >> choice;
			checkValue(choice, regex("^([1-7]{1}$)"));
		}
		catch (const std::exception& e)
		{
			std::cerr << "Ошибка: " << e.what() << std::endl;
		}		

		switch (stoi(choice))
		{
		case 1:  // Создание карты

			addCard(wallet, wallet_count);
			break;

		case 2: // Пополнение карты
			try
			{
				cout << "Enter card number - ";
				getline(std::cin, cardNumber);
				checkValue(cardNumber, regex("([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})"), "XXXX-XXXX-XXXX-XXXX");

			}
			catch (const std::exception& e)
			{
				std::cerr << "Ошибка: " << e.what() << std::endl;
			}

			for (size_t i = 0; i < 5; i++)
			{
				if (wallet->cards[i].getCardNo() == cardNumber)
				{
					try
					{
						cout << "Enter amount - ";
						getline(std::cin, cardBalance);
						checkValue(cardBalance, regex("^[0-9]{0,}[.]?[0-9]{1,2}$"));
					}
					catch (const std::exception& e )
					{
						std::cerr << "Ошибка: " << e.what() << std::endl;
					}
					newBalance.createBalance(cardBalance);
					wallet->cards[i].increaseBalance(&newBalance);
				}
				else if (i == 4 && wallet->cards[i].getCardNo() != cardNumber)
				{
					cout << "Card not found.";
				}
			}
			cardBalance = "";
			cardNumber = "";

			break;

		case 3:  // Покупка
			try
			{
				cout << "Enter card number - ";
				getline(cin, cardNumber);
				checkValue(cardNumber, regex("([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})"), "XXXX-XXXX-XXXX-XXXX");
			}
			catch (const exception& e)
			{
				cerr << "Ошибка: " << e.what() << endl;
			}

			for (size_t i = 0; i < 5; i++)
			{
				if (wallet->cards[i].getCardNo() == cardNumber)
				{
					try
					{
						cout << "Enter amount - ";
						getline(cin, amount);
						checkValue(amount, regex("^[0-9]{1,}$"));
					}
					catch (const exception& e)
					{
						cerr << "Ошибка: " << e.what() << endl;

					}
					newBalance.createBalance(amount);
					wallet->cards[i].decreaseBalance(&newBalance);

					cout << "Choose a category:" << endl
						<< "1. Food" << endl
						<< "2. Sport" << endl
						<< "3. Medicine" << endl
						<< "4. Another thing"
						<< "Enter choise - "; cin >> choice_category;

					switch (choice_category)
					{
					case1:
						category = "Food";
						break;
					case2:
						category = "Sport";
						break;
					case3:
						category = "Medicine";
						break;
					case4:
						category = "Another thing";
						break;
					}
					_time = createTime();
					Expenses expenses(_time, amount, category);
					wallet->expenses.push_back(expenses);
				}
				else if (i == 4 && wallet->cards[i].getCardNo() != cardNumber)
				{
					cout << "Card not found.";
				}
			}
			amount = "";
			cardNumber = "";

			break;

		case 4:  // Вывод информации кошелька

			cout << wallet;

			break;

		case 5:  // Вывод информации карты

			try
			{
				cout << "Enter card number - ";
				getline(cin, cardNumber);
				checkValue(cardNumber, regex("([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})"), "XXXX-XXXX-XXXX-XXXX");
			}
			catch (const exception& e)
			{
				cerr << "Ошибка: " << e.what() << std::endl;
			}
			for (size_t i = 0; i < 5; i++)
			{
				if (wallet->cards[i].getCardNo() == cardNumber)
				{
					cout << wallet->cards[i];
				}
				else if (i == 4 && wallet->cards[i].getCardNo() != cardNumber)
				{
					cout << "Card not found.";
				}
			}
			break;
		case 6:

			cout << "Choose a category:" << endl
				<< "1. Day" << endl
				<< "2. Weak" << endl
				<< "3. Month" << endl
				<< "Enter choise - "; cin >> choice_category;

			if (wallet->expenses.size() == 0)
			{
				cout << "No expenses" << endl;
			}
			else
			{
				switch (choice_category)
				{
				case 1:
					for (size_t i = 0; i < wallet->expenses.size(); i++)
					{
						if (createDate() == wallet->expenses[i].getDate())
						{
							cout << wallet->expenses[i] << endl;
						}
					}
					break;
				case 2:
					for (size_t i = 0; i < wallet->expenses.size(); i++)
					{
						for (int j = 0; j < 7; j++)
						{
							if (createPastDays(j) == wallet->expenses[i].getDate())
							{
								cout << wallet->expenses[i] << endl;
							}
						}
					}
					break;
				case 3:
					for (size_t i = 0; i < wallet->expenses.size(); i++)
					{
						for (int j = 0; j < 30; j++)
						{
							if (createPastDays(j) == wallet->expenses[i].getDate())
							{
								cout << wallet->expenses[i] << endl;
							}
						}
					}
					break;
				}
			}
			break;

		case 7:
			key = false;
			break;
		default:
			break;
		}
	}
}