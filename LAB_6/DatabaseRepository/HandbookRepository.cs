﻿using Phonebook.DAL;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository
{
    public class HandbookRepository : IRepository<HandbookRecord>
    {
        private ApplicationDbContext _context;
        public static int scope_id = 0;
        public HandbookRepository(ApplicationDbContext context)
        {
            _context = context;
            scope_id++;
        }
        public void Create(HandbookRecord item)
        {
            _context.HandbookRecords.Add(item);
        }

        public void Delete(int id)
        {
            HandbookRecord handbookRecord = _context.HandbookRecords.Find(id);
            _context.HandbookRecords.Remove(handbookRecord);
        }

        public HandbookRecord GetRecord(int id)
        {
            return _context.HandbookRecords.Find(id);
        }

        public IEnumerable<HandbookRecord> GetRecords()
        {
            return _context.HandbookRecords.ToList();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if ((ex.InnerException.InnerException as SqlException).Number == 2601)
                {
                    throw new Exception("Данные уже существуют");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Update(HandbookRecord item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
