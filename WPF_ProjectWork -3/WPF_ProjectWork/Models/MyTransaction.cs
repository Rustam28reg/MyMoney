﻿using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_ProjectWork.Enums;

namespace WPF_ProjectWork.Services.Classes
{
    class MyTransaction
    {
        public string Description { get; set; } //описание
        public double Value { get; set; } //Количество
        public DateTime FullTime { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public Color Color { get; set; }

        public MyTransaction() {}

        public MyTransaction(DateTime date, string description, double value, DateTime allDate, string category, Color color)
        {
            Description = description;
            Value = value;
            Date = date;
            FullTime = allDate;
            Category = category;
            Color = color;
        }

        public MyTransaction(DateTime date, string description, double value, DateTime allDate, Expense category)
        {
            Description = description;
            Value = value;
            Date = date;
            FullTime = allDate;
            Category = category.ToString();
            switch (category)
            {
                case Expense.Car:
                    Color = Colors.DarkViolet;
                    break;
                case Expense.Phone:
                    Color = Colors.Blue;
                    break;
                case Expense.Food:
                    Color = Colors.Chartreuse;
                    break;
                case Expense.Health:
                    Color = Colors.IndianRed;
                    break;
                case Expense.Party:
                    Color = Colors.LightSkyBlue;
                    break;
                case Expense.Hygiene:
                    Color = Colors.Red;
                    break;
                case Expense.Present:
                    Color = Colors.Aqua;
                    break;
                case Expense.Pet:
                    Color = Colors.Aquamarine;
                    break;
                case Expense.Rest:
                    Color = Colors.Gold;
                    break;
                case Expense.Restaurant:
                    Color = Colors.MediumVioletRed;
                    break;
                case Expense.Sport:
                    Color = Colors.Goldenrod;
                    break;
                case Expense.Taxi:
                    Color = Colors.Yellow;
                    break;
                case Expense.Travel:
                    Color = Colors.LimeGreen;
                    break;
                case Expense.Cloth:
                    Color = Colors.Coral;
                    break;
            }
        }

        public MyTransaction(DateTime date, string description, double value, DateTime allDate, Income category)
        {
            Description = description;
            Value = value;
            Date = date;
            FullTime = allDate;
            Category = category.ToString();

            switch (category)
            {
                case Income.Salary:
                    Color = Colors.DarkViolet;
                    break;
                case Income.Gift:
                    Color = Colors.Blue;
                    break;
                case Income.Obligation:
                    Color = Colors.Chartreuse;
                    break;
                case Income.Other:
                    Color = Colors.IndianRed;
                    break;
            }
        }
    }
}
