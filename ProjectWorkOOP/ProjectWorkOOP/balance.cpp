#include "balance.h"

Balance::Balance() = default;
Balance::Balance(int left, int right)
{
	this->left = left;
	this->right = right;
}

Balance::~Balance(){}

Balance& Balance::operator +(const Balance& num)
{
	Balance result;

	if ((this->right + num.right) > 99)
	{
		result.left = this->left + 1;
		result.right =((this->right + num.right) - 100);
	}
	else
	{
		result.left = this->left + num.left;
		result.right = this->right + num.right;
	}

	return result;
}

Balance& Balance::operator - (const Balance& num)
{
	Balance result;

	if (this->right < num.right)
	{
		result.left = this->left - 1;
		result.right = this->right + (100 - num.right);
	}
	else
	{
		result.left = this->left - num.left;
		result.right = this->right - num.right;
	}

	return result;
}


Balance& Balance::operator +=(const Balance* num)
{

	this->left += num->left;
	this->right += num->right;

	if (this->right > 100)
	{
		this->left += this->right / 100;
		this->right = this->right % 100;
	}
	
	return *this;
}

Balance& Balance::operator -=(const Balance* num)
{

	if (this->right < num->right)
	{
		this->left -= 1;
		this->right += 100 - num->right;
	}
	else
	{
		this->right -= num->right;
	}

	return *this;
}

Balance& Balance::operator =(const string& strBalance)
{
	int i{};
	if (strBalance.find('.') != string::npos) // npos - статическое поле стринга - обозначает не найдено (no position)
	{
		while (strBalance[i] != '.')
		{
			this->left *= 10;
			this->left += strBalance[i] - 48;
			i++;
		}
		i++;
		while (strBalance[i] != '\0')
		{
			this->right *= 10;
			this->right += strBalance[i] - 48;
			i++;
		}
	}
	else
	{
		while (strBalance[i] != '\0')
		{
			this->left *= 10;
			this->left += strBalance[i] - 48;
			this->right = 0;
			i++;
		}
	}
	return *this;
}

ostream& operator<<(ostream& os, const Balance& obj)
{
	os << obj.getLeft() << "." << obj.getRight();
	return os;
}

istream& operator>>(istream& is, Balance& obj) {
	std::string input;
	is >> input;

	int i{};

	if (input.find('.') != string::npos) // npos - статическое поле стринга - обозначает не найдено (no position)
	{
		while (input[i] != '.')
		{
			obj.left *= 10;
			obj.left += input[i] - 48;
			i++;
		}
		i++;
		while (input[i] != '\0')
		{
			obj.right *= 10;
			obj.right += input[i] - 48;
			i++;
		}
	}
	else
	{
		while(input[i] != '\0')
		{
			obj.left *= 10;
			obj.left += input[i] - 48;
			obj.right = 0;
			i++;
		}
	}

	return is;
}


bool Balance::operator <=(const Balance& other)
{
	if (this->left < other.left)
	{
		return true;
	}
	else if(this->left == 0 && this->right < other.right)
	{
		return true;
	}
	else
	{
		return false;
	}
	
}

Balance Balance::createBalance(string str)
{
	int i{};
	if (str.find('.') != string::npos)
	{
		while (str[i] != '.')
		{
			this->left *= 10;
			this->left += str[i] - 48;
			i++;
		}
		i++;
		while (str[i] != '\0')
		{
			this->right *= 10;
			this->right += str[i] - 48;
			i++;
		}
	}
	else
	{
		while (str[i] != '\0')
		{
			this->left *= 10;
			this->left += str[i] - 48;
			this->right = 0;
			i++;
		}
	}

	return *this;
}

int Balance::getLeft() const
{
	return this->left;
}
int Balance::getRight() const
{
	return this->right;
}
void Balance::setLeft(int num)
{
	this->left = num;
}
void Balance::setRight(int num)
{
	this->right = num;
}