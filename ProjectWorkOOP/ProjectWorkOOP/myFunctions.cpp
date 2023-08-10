#include "myFunctions.h"

void checkValue(std::string& str, std::regex regexTipe, const string& mesage)
{
	while (true)
	{
		if (!std::regex_match(str, regexTipe)) {
			if (mesage == "")
			{
				std::cout << "Invalid input!" << std::endl;
			}
			else
			{
				std::cout << mesage << std::endl;
			}
			std::cout << "Please re-enter value: " << std::endl; std::cin >> str;
			continue;
		}
		break;
	}
}


string createTime()
{
	time_t currentTime;
	time(&currentTime); // �������� ������� ����� � ��������

	tm timeStruct;
	localtime_s(&timeStruct, &currentTime); // �������� ��������� ������� ��� ������� strftime

	char buffer[20]; // strftime ��������� � �������� ��������� char ������ 

	strftime(buffer, sizeof(buffer), "%d-%m-%Y%H:%M:%S", &timeStruct); // ����������� ����� � ������
	string time = buffer;

	return time;
}

string createDate()
{
	time_t currentTime;
	time(&currentTime); // �������� ������� ����� � ��������

	tm timeStruct;
	localtime_s(&timeStruct, &currentTime); // �������� ��������� ������� ��� ������� strftime

	char buffer[30]; // strftime ��������� � �������� ��������� char ������ 

	strftime(buffer, sizeof(buffer), "%d-%m-%Y", &timeStruct); // ����������� ����� � ������
	string date = buffer;

	return date;
}

string createPastDays(int sec)
{
	int secondsDay{ 86400 };
	secondsDay *= sec;

	time_t dayTime{ secondsDay };
	time_t currentTime;
	time(&currentTime);
	currentTime -= dayTime;

	tm timeStruct;
	localtime_s(&timeStruct, &currentTime); // �������� ��������� ������� ��� ������� strftime

	char buffer[30]; // strftime ��������� � �������� ��������� char ������ 

	strftime(buffer, sizeof(buffer), "%d-%m-%Y", &timeStruct); // ����������� ����� � ������
	string date = buffer;

	return date;
}




