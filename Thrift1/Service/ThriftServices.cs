/*using Microsoft.EntityFrameworkCore;
using Thrift1.Data;
using Thrift1.Models;
using Thrift1.ViewModel;

namespace Thrift1.Service
{
    public class ThriftServices : IThriftServices
    {

        private readonly ThriftDbContext _context;
        public ThriftServices(ThriftDbContext context)
        {
            _context = context;
        }

        public Task<DetailsViewModel> Details(int categoryId, int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, EditViewModel editViewModel)
        {
            throw new NotImplementedException();
        }

        Task IThriftServices.Create(CreateViewModel createViewModel)
        {
            throw new NotImplementedException();
        }

        Task IThriftServices.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<DetailsViewModel> IThriftServices.Details(int categoryId)
        {
            throw new NotImplementedException();
        }

        async Task<List<IndexViewModel>> IThriftServices.Index()
        {
            return _context.Categories != null ?
                       View(await _context.Categories.ToListAsync()) :
                       Problem("Entity set 'ThriftDbContext.Categories'  is null.");
        }

       
    }
}

*/