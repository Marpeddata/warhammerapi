using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using warhammer.Entities;

namespace warhammer.Interfaces
{
    public interface IWarhammerRepository
    {

        ICollection<Model> GetModels();

        Model GetModel(int id);
        Task<ActionResult<Model>> CreateModel(Model model);

    }
}
