#pragma once
#include <vector>
#include "person.h"
#include "card.h"
#include "expenses.h"
#include <json.hpp>
#include <fstream>
using namespace nlohmann;
using namespace std;

class Wallet {
private:
	Person user{};
	string walletName{};
	string wallet_num{};
public:
	int cards_count{};
	Balance walletBalance{};
	Balance fullBalance{};
	Card* cards = new Card[5]{};
	vector <Expenses> expenses;
	json* cards_date = new json[5];

	Wallet();
	Wallet(int cards_count, Person& user, string& walletName, string& wallet_num, Balance& walletBalance, Balance& allBalance, json*& cards_date, Card* cards, const vector <Expenses>& expenses);

	~Wallet();

	Person getPerson()const;

	string getWalletNum()const;

	string getWalletName()const;

	string getUserSurname()const;

	string getUserName()const;


	void setWalletCode(string number);

	void setWalletName(string wallet_name);

	void setUserSurname(string _name);

	void setUserName(string _surname);

	friend ostream& operator <<(std::ostream& os, const Wallet& obj);

	void deleteWallet(string wallet_index);

};


void printwalletInfo(Wallet* wallet);
Wallet* createWallet(Person& user, string wallet_index);
void addCard(Wallet* wallet, int wallet_count);