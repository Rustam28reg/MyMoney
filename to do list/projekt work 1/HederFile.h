struct Time
{
	int day;
	int month;
	int year;

	int hour;
	int minute;

};
struct list
{
	char* name = new char[30] {};
	char* content = new char[200] {};
	char priority;
	Time dateTime;
};


int	checking(char num);
void createList(list* _doList, int i);
void showCase(list* _dolist, int i);
void showAllList(list* _dolist, int _len);
void deleteCase(list* _dolist, int _choice, int _len);
void changeList(list* _doList, int i);
void caseSearch(list* _dolist);