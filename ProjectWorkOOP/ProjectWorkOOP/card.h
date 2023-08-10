#pragma once
#include <string>
#include "balance.h"
#include "myFunctions.h"

using namespace std;

class Card
{
private:
    string card_num{}, card_date{}, card_cvc{};
    Balance balance{};
public:
    Card();
    Card(string cardNo, string cardDate, string cardCvc, Balance balance);

    ~Card();

    void increaseBalance(Balance* amount);

    bool decreaseBalance(Balance* amount);    

	string getCardNo() const;

	string getCardDate()const;

	string getCardCvc()const;

	Balance getCardBalance()const;

    friend ostream& operator<<(ostream& os, const Card& obj);

};

Card* createCard(json*& cards_date, string wallet_index, int index);
void printCardInfo(Card card);

