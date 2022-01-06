using clean_arch.common.Domain.Seedwork.Interfaces;
using clean_arch.domain.Aggregates.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.infrastructure.Persistence.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BankRepository> _logger;

        #region Ctor
        public BankRepository(ApplicationDbContext context, ILogger<BankRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Bank> CreateAsync(Bank entity)
        {
            try
            {
                return (await _context.Banks.AddAsync(entity)).Entity;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _context.Banks.FindAsync(id);
                _context.Banks.Remove(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public IQueryable<Bank> GetAsQueryable() => _context.Banks.AsQueryable().AsNoTracking();

        public async Task<Bank> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Banks.FindAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Bank> UpdateAsync(Bank entity)
        {
            try
            {
                return  _context.Banks.Update(entity).Entity;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
