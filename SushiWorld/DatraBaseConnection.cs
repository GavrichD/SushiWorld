﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiWorld
{
    public class DataBaseConnection
    {

        public int userActiveId;
        public string URL = "data source=0.tcp.eu.ngrok.io, 16847;" +
            "Database=Sushi_World;" +
            "User Id=DanyaGavrichenko;" +
            "Password=danya_003;" +
            "TrustServerCertificate=True;";


        // получение id пользователя для регистрации
        public void takeTruthId()
        {
            using (SqlConnection conn = new SqlConnection(URL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
                    Use Sushi_World
                    SELECT [Id Пользователя]
                    FROM Пользователь;
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string count = "" + dr["Id Пользователя"];
                        userActiveId = Convert.ToInt32("" + dr["Id Пользователя"]) + 1;
                    }
                    dr.Close();
                }
                conn.Close();
            }
        }

        // Получение списка блюд с информацией из базы данных
        public Dictionary<string, Dictionary<string, string>> DataBaseUserData(string choosenFoodCategory)
        {
            Dictionary<string, Dictionary<string, string>> foodCardInformation = new Dictionary<string, Dictionary<string, string>>();

            using (SqlConnection conn = new SqlConnection(URL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    Use Sushi_World
                    SELECT *
                    FROM [Пункт Меню]
                    Where Категория = N'{choosenFoodCategory}';
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dictionary<string, string> insertDict = new Dictionary<string, string>()
                        {
                            {"Количество", ""}, {"Время", ""}, {"Цена", ""}, {"Вес", ""}, {"Рейтинг", ""}, {"Фото", ""},
                        };

                        if (!foodCardInformation.ContainsKey(("" + dr["Название блюда"]).Trim()))
                        {


                            insertDict["Количество"] = ("" + dr["Количество"]).Trim();
                            insertDict["Время"] = ("" + dr["Время готовности"]).Trim();
                            insertDict["Цена"] = ("" + dr["Цена"]).Trim();
                            insertDict["Вес"] = ("" + dr["Вес"]).Trim();
                            insertDict["Рейтинг"] = ("" + dr["Рейтинг"]).Trim();
                            insertDict["Фото"] = ("" + dr["Фотография блюда"]).Trim();

                            foodCardInformation[("" + dr["Название блюда"]).Trim()] = insertDict;
                        }

                    }
                    dr.Close();
                }
                conn.Close();
            }
            return foodCardInformation;
        }

        // получение информации по 1 блдюду
        public Dictionary<string, string> returnAllFoodInformation(string ChoosenFoodName)
        {

            Dictionary<string, string> cardFoodInformationDict = new Dictionary<string, string>()
            {
                {"Название","" }, {"Количество", ""}, {"Время", ""}, {"Цена", ""},
                {"Вес", ""}, {"Рейтинг", ""}, {"Фото", ""}, {"Ингридиент", "" }
            };
            using (SqlConnection conn = new SqlConnection(URL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    Use Sushi_World
                    SELECT *
                    FROM [Пункт Меню]
                    Where [Название блюда] = N'{ChoosenFoodName}';
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {


                        cardFoodInformationDict["Название"] = ("" + dr["Название блюда"]).Trim();
                        cardFoodInformationDict["Количество"] = ("" + dr["Количество"]).Trim();
                        cardFoodInformationDict["Время"] = ("" + dr["Время готовности"]).Trim();
                        cardFoodInformationDict["Цена"] = ("" + dr["Цена"]).Trim();
                        cardFoodInformationDict["Вес"] = ("" + dr["Вес"]).Trim();
                        cardFoodInformationDict["Рейтинг"] = ("" + dr["Рейтинг"]).Trim();
                        cardFoodInformationDict["Фото"] = ("" + dr["Фотография блюда"]).Trim();
                        cardFoodInformationDict["Ингридиент"] += ("" + dr["Ингридиент"]).Trim() + "-";



                    }
                    dr.Close();
                }
                conn.Close();
            }
            return cardFoodInformationDict;
        }


        public Dictionary<string, string> returnBasketFoodInf(string BasketFoodName)
        {
            Dictionary<string, string> basketFoodInformation = new Dictionary<string, string>()
            {
                {"Название","" }, {"Цена", ""},
                {"Вес", ""}, {"Фото", ""}
            };
            using (SqlConnection conn = new SqlConnection(URL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    Use Sushi_World
                    SELECT [Название блюда], Цена, Вес, [Фотография блюда]
                    FROM [Пункт Меню]
                    Where [Название блюда] = N'{BasketFoodName}';
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {


                        basketFoodInformation["Название"] = ("" + dr["Название блюда"]).Trim();


                        basketFoodInformation["Цена"] = ("" + dr["Цена"]).Trim();
                        basketFoodInformation["Вес"] = ("" + dr["Вес"]).Trim();
                        basketFoodInformation["Фото"] = ("" + dr["Фотография блюда"]).Trim();




                    }
                    dr.Close();
                }
                conn.Close();
            }
            return basketFoodInformation;
        }

        /*// Получение к базе данных для авторизации
        public Dictionary<string, Dictionary<string, string>> DataBaseUserData(string UserDataSet)
        {
            Dictionary<string, Dictionary<string, string>> UserData = new Dictionary<string, Dictionary<string, string>>();

            using (SqlConnection conn = new SqlConnection(URL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    Use Sushi_World
                    SELECT [Номер телефона], [Пароль]
                    FROM [Пользователь]
                    Where [ID пользователя] = N'1';
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {


                    }
                    dr.Close();
                }
                conn.Close();
            }
            return UserData;
        }*/
    }
}
