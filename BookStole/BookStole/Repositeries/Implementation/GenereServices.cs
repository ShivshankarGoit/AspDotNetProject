﻿using BookStole.Data;
using BookStole.Models.Domain;
using BookStole.Repositeries.Abstracts;

namespace BookStole.Repositeries.Implementation
{
    public class GenereServices : IGenereService
    {

        private readonly ApplicationDbContext context;
        public GenereServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Genre model)
        {
            try
            {
                context.Genre.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Genre.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return context.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genre.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                context.Genre.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
