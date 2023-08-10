#include "wallet.h"

Wallet::Wallet() = default;
Wallet::Wallet(int cards_count, Person& user, string& walletName, string& wallet_num, Balance& walletBalance, Balance& allBalance, json*& cards_date, Card* cards = nullptr, const vector <Expenses>& expenses = vector<Expenses>())
{
    this->cards_count = cards_count;
    this->user = user;
    this->walletName = walletName;
    this->wallet_num = wallet_num;
    this->walletBalance = walletBalance;
    this->fullBalance = allBalance;
    this->cards = cards;
    this->expenses = expenses;
}

Wallet::~Wallet(){}

Person Wallet::getPerson()const
{
    return this->user;
}
string Wallet::getWalletNum()const
{
    return this->wallet_num;
}
string Wallet::getWalletName()const
{
    return this->walletName;
}
string Wallet::getUserSurname()const
{
    return this->user.getSurName();
}
string Wallet::getUserName()const
{
    return this->user.getName();
}

void Wallet::setWalletCode(string number)
{
    this->wallet_num = number;
}
void Wallet::setWalletName(string wallet_name)
{
    this->walletName = wallet_name;
}
void Wallet::setUserName(string _name)
{
    this->user.setName(_name);
}
void Wallet::setUserSurname(string _surname)
{
    this->user.setSurName(_surname);
}

ostream& operator<<(ostream& os, const Wallet& obj) 
{
    os << "Wallet Name - " << obj.walletName << endl        
        << "Wallet num - " << obj.wallet_num << endl
        << "User name - " << obj.user << endl
        << "Wallet account balance - " << obj.walletBalance << endl
        << "Full wallet balance - " << obj.fullBalance << endl;

    return os;
}


void printwalletInfo(Wallet* wallet)    // Это по приколу
{
    cout << "Wallet Name: " << wallet->getWalletName() << endl;
    cout << "User Surname: " << wallet->getUserSurname() << endl;
    cout << "User Name: " << wallet->getUserName() << endl;
    cout << "Wallet num: " << wallet->getWalletNum() << endl;
    cout << "Wallet account balance: " << wallet->walletBalance << endl;
    cout << "Full wallet balance: " << wallet->fullBalance << endl;
}

void addCard(Wallet* wallet, int wallet_count)
{
    try
    {
		wallet->cards[wallet->cards_count] = *createCard(wallet->cards_date, to_string(wallet_count+1), wallet_count);
    }
    catch (const std::exception& e)
    {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }
    wallet->cards_count++;
}

Wallet* createWallet(Person& user, string wallet_index)
{
    string walletName{}, wallet_num{}, newBalance{};
    Balance walletBalance{}, allWalletBalance{};
    Card* card = new Card[5]{};
    int cards_count{}, choice{};

    cin.ignore();

    cout << "Enter wallet name: "; cin >> walletName;
    checkValue(walletName, regex("^[a-zA-Z1-9]{4,10}$"));
    cout << "Enter wallet number: "; cin >> wallet_num;
    checkValue(wallet_num, regex("([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})[- ]?([0-9]{4})"));
    cout << "Enter wallet balance: "; cin >> newBalance;
    checkValue(newBalance, regex("^[0-9]{0,}[.]?[0-9]{0,2}$"));
    walletBalance = newBalance;
    cout << "Do you want to made Card ? \n Yes - 1 \n No - 2 \n Enter your choise - "; cin >> choice;

    // запись созданного кошелька 
    json* cards_date = new json[5];
    json wallet_date;
    wallet_date["WalletName"] = walletName;
    wallet_date["UserSurname"] = user.getSurName();
    wallet_date["UserName"] = user.getName();
    wallet_date["WalletNum"] = wallet_num;
    wallet_date["WalletAccountBalance"] = walletBalance.getLeft() + "." + walletBalance.getRight();
    wallet_date["FullWalletBalance"] = allWalletBalance.getLeft() + "." + allWalletBalance.getRight();

    ofstream outputFile(wallet_index + "-wallet_date.json");
    if (!outputFile.is_open()) {
        cout << "Unable to open the file for writing." << std::endl;
    }
    outputFile << wallet_date.dump(4);
    outputFile.close();

    if (choice == 1)
    {
        card[cards_count] = *createCard(cards_date, wallet_index, 0);
        allWalletBalance = walletBalance + card->getCardBalance();
        Wallet* wallet = new Wallet(cards_count, user, walletName, wallet_num, walletBalance, allWalletBalance, cards_date, card);
        return wallet;
    }
    else if (choice == 2)
    {
        Wallet* wallet = new Wallet(cards_count, user, walletName, wallet_num, walletBalance, allWalletBalance, cards_date);
        return wallet;
    }    
}

void Wallet::deleteWallet(string wallet_index)
{
    this->user.deleteUser(wallet_index);
    this->walletName = "";
    this->wallet_num = "";
    this->cards_count = 0;
    this->walletBalance.setLeft(0);
    this->walletBalance.setRight(0);
    this->fullBalance.setLeft(0);
    this->fullBalance.setRight(0);
    this->cards = nullptr;
    vector <Expenses> *expenses = nullptr;

    json wallet_date;
    wallet_date["WalletName"] = walletName;
    wallet_date["UserSurname"] = user.getSurName();
    wallet_date["UserName"] = user.getName();
    wallet_date["WalletNum"] = wallet_num;
    wallet_date["WalletAccountBalance"] = walletBalance.getLeft() + "." + walletBalance.getRight();
    wallet_date["FullWalletBalance"] = fullBalance.getLeft() + "." + fullBalance.getRight();

    ofstream outputFile(wallet_index+"-wallet_date.json");
    if (!outputFile.is_open()) {
        cout << "Unable to open the file for writing." << std::endl;
    }
    outputFile << wallet_date.dump(4);
    outputFile.close();
}