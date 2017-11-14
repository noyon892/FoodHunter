﻿using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        Food Get(int id);
        int Insert(Food food);
        int Update(Food food);
        int Delete(int id);
    }
}