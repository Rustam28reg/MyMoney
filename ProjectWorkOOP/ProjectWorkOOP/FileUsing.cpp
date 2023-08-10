#include "FileUsing.h"
int loadetLen(int& wallet_count) 
{
	json loaded_len;
	ifstream inputFile("wallet_len.json");
	if (!inputFile.is_open()) {
		cout << "Unable to open the file for reading 1111." << std::endl;
		return 1;
	}
	inputFile >> loaded_len;
	inputFile.close();
	wallet_count = loaded_len["wallet_len"];
}

int loadWalletData(Wallet*& wallet, int& wallet_count)
{
	json loadet_walet_data;

	for (size_t i = 0; i < wallet_count; i++)
	{
		ifstream inputFile(to_string(wallet_count) + "-wallet_date.json");
		if (!inputFile.is_open()) {
			cout << "Unable to open the file for reading 22222." << std::endl;
			return 1;
		}
		inputFile >> loadet_walet_data;
		inputFile.close();

		wallet[i].setUserName(loadet_walet_data["WalletName"]);
		wallet[i].setUserSurname(loadet_walet_data["UserSurname"]);
		wallet[i].setUserName(loadet_walet_data["UserName"]);
		wallet[i].setWalletCode(loadet_walet_data["WalletNum"]);
		wallet[i].walletBalance = loadet_walet_data["WalletAccountBalance"];
		wallet[i].fullBalance = loadet_walet_data["FullWalletBalance"];
	}

	return 0;
}