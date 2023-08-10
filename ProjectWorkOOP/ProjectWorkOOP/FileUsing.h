#pragma once
#include <iostream>
#include <string>
#include "wallet.h"
#include <json.hpp>
#include <fstream>

int loadetLen(int& wallet_count);
int loadWalletData(Wallet*& wallet, int& wallet_count);
