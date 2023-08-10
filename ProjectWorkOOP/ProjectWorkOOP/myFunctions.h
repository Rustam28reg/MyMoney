#pragma once
#include <iostream>
#include <regex>
#include <json.hpp>
#include <fstream>
using namespace nlohmann;
using namespace std;

void checkValue(string& str, regex regexTipe, const string& = "");
string createTime();
string createDate();
string createPastDays(int sec);




