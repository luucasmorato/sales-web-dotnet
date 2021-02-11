﻿using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return  _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj =  _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChangesAsync();
        }

        public void Remove(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public void Update(Seller obj)
        {
            bool hasAny = _context.Seller.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
