using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext db) : base(db) { }

        public void Update(Company company)
        {
            var existingCompany = _db.Companies.Find(company.Id);
            if (existingCompany != null)
            {
                _db.Entry(existingCompany).CurrentValues.SetValues(company);
            }
        }
    }
}
