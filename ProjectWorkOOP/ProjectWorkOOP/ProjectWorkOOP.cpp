#include "FileUsing.h"
#include "wallet_space.h"
#include "myFunctions.h"
#include <fstream>
#include <json.hpp>
#include <string>
using namespace nlohmann;

int main()
{

	int wallet_count{};
	loadetLen(wallet_count);   
	
	Wallet* wallet = new Wallet[5]{};
	Person* user{};
	bool key{ true };
	string wallet_number{};
	string wallet_index = to_string(wallet_count+1);
	
	loadWalletData(wallet, wallet_count);	
	
	while (key)
	{
		string choice{};

		cout << "1.Create Wallet." << endl
			<< "2.Get into Wallet." << endl
			<< "3.Delete wallet." << endl
			<< "4. Exit." << endl;
		try
		{
			cout << "Enter your choice - "; cin >> choice;
			checkValue(choice, regex("^([1-4]{1}$"));
		}
		catch (const std::exception& e)
		{
			cout << "Îøèáêà: " << e.what() << std::endl;
		}


		system("cls");

		switch (stoi(choice))
		{
		case 1:
			while (true)
			{
				try
				{
					user = createPerson(wallet_index);
				}
				catch (const exception& e)
				{
					std::cerr << "Îøèáêà: " << e.what() << std::endl;
					continue;
				}
				break;
			}

			try
			{
				wallet[wallet_count] = *createWallet(*user, wallet_index);
			}
			catch (const exception& e)
			{
				std::cerr << "Îøèáêà: " << e.what() << std::endl;
			}

			wallet_count++;

			break;

		case 2:

			cout << "Enter Wallet number - "; cin >> wallet_number;

			for (int i = 0; i < 5; i++)
			{
				if (wallet[i].getWalletNum() == wallet_number)
				{
					wallet_space(&wallet[i], i);
					break;
				}
				else if (i == 4 && wallet[i].getWalletNum() != wallet_number)
				{
					cout << "Wallet not found." << endl;
				}
			}
			break;

		case 3:
			cout << "Enter wallet number for delete - "; cin>>wallet_number;

			for (int i = 0; i < 5; i++)
			{
				if (wallet[i].getWalletNum() == wallet_number)
				{
					wallet[i].deleteWallet(to_string(i+1));
					wallet_count--;
				}
				else if (i == 4 && wallet[i].getWalletNum() != wallet_number)
				{
					cout << "Wallet not found." << endl;
				}
			}

			break;
		case 4:
			key = false;
			json count;
			count["wallet_len"] = wallet_count;
			ofstream outputFile("wallet_len.json");
			if (!outputFile.is_open()) {
				cout << "Unable to open the file for writing." << std::endl;
			}
			outputFile << count.dump(4);  
			outputFile.close();

			break;
		}

	}
	return 0;
}