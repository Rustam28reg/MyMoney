#include "card.h"



Card::Card() = default;
Card::Card(string cardNo, string cardDate, string cardCvc, Balance balance)
{
    this->card_num = cardNo;
    this->card_date = cardDate;
    this->card_cvc = cardCvc;
    this->balance = balance;
}

Card::~Card(){}

void Card::increaseBalance(Balance* amount)
{
    this->balance += amount;
}
bool Card::decreaseBalance(Balance* amount)
{
    if (this->balance <= *amount)
    {
		this->balance -= amount;
        return true;
    }
    else
    {
        return false;
    }
}
string Card::getCardNo()const
{
    return this->card_num;
}
string Card::getCardDate()const
{
    return this->card_date;
}
string Card::getCardCvc()const
{
    return this->card_cvc;
}
Balance Card::getCardBalance()const
{
    return this->balance;
}

ostream& operator<<(ostream& os, const Card& obj)
{
    os << "Wallet Name: " << obj.card_num << endl
        << "Wallet num: " << obj.card_date << endl
        << "User name - " << obj.card_cvc << endl
        << "Wallet account balance: " << obj.balance << endl;

    return os;
}


Card* createCard(json*& cards_date, string wallet_index, int index)
{
    string cardNo{};
    string cardDate{};
    string cardCvc{};
    string cardBalance{};

    regex cardNumberTipe("([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})");
    regex cardDateTipe("(0[1-9]|1[0-2])[/ ]?(20[2-9]{2})");
    regex cardCvcTipe("[0-9]{3}");
    regex cardBalanceTipe("^[0-9]{0,}[.]?[0-9]{1,2}$");

    cin.ignore();
    cout << "Enter Card No - ";
    getline(cin, cardNo);
    checkValue(cardNo, cardNumberTipe);

    cin.ignore();
    std::cout << "Enter Card Date MM/YYYY - ";
    getline(cin, cardDate);
    checkValue(cardDate, cardDateTipe);

    cin.ignore();
    std::cout << "Enter Card CVC - ";
    getline(cin, cardCvc);
    checkValue(cardCvc, cardCvcTipe);

    cin.ignore();
    std::cout << "Enter Card balance - ";
    getline(cin, cardBalance);
    checkValue(cardBalance, cardBalanceTipe);

    cards_date[index]["CardNo"] = cardNo;
    cards_date[index]["CardDate"] = cardDate;
    cards_date[index]["CardCvc"] = cardCvc;
    cards_date[index]["CardBalance"] = cardBalance;


    ofstream outputFile(wallet_index + '_' + to_string(index) + "-card_date.json");
    if (!outputFile.is_open()) {
        cout << "Unable to open the file for writing." << std::endl;
    }
    outputFile << cards_date[index].dump(4);
    outputFile.close();

    Balance newBalance{};
    newBalance.createBalance(cardBalance);

    Card* card = new Card(cardNo, cardDate, cardCvc, newBalance);

    return card;
}

void printCardInfo(Card card)  // этот метод по приколу сделан =)
{
    std::cout << "Card No: " << card.getCardNo() << std::endl;
    std::cout << "Card Date: " << card.getCardDate() << std::endl;
    std::cout << "Card Cvc: " << card.getCardCvc() << std::endl;
    std::cout << "Card Balance: " << card.getCardBalance() << std::endl;
}