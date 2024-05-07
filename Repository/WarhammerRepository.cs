using warhammer.Entities;
using warhammer.Interfaces;
using warhammer.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace warhammer.Repository
{
    public class WarhammerRepository : IWarhammerRepository
    {

        private readonly DBcontext _context;

        public WarhammerRepository(DBcontext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Model>> CreateModel(Model model)
        {

            _context.models.Add(model);
            await _context.SaveChangesAsync();

            return model;


        }

        public Model GetModel(int id)
        {
            var list = _context.models;

            foreach (Model model in list) { 
            
                if(model.id == id)
                {
                    return model;
                }
            
            }


            return null;
        }

        ICollection<Model> IWarhammerRepository.GetModels()
        {
            return _context.models.ToList();
        }
    }
}
