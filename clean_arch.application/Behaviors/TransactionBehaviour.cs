//using clean_arch.application.Extensions;
//using clean_arch.infrastructure;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Serilog.Context;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SAFRA.SMCMS.MembershipService.Application.Behaviors
//{
//    //TODO: Register to use. DO NOT DELETE!!!
//    //public class TransactionWithIntegrationEventsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//    //{
//    //    #region Variable(s)
//    //    private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
//    //    private readonly ApplicationDbContext _dbContext;
//    //    private readonly IMembershipIntegrationEventService _membershipIntegrationEventService;

//    //    public TransactionWithIntegrationEventsBehaviour(ILogger<TransactionBehaviour<TRequest, TResponse>> logger, ApplicationDbContext dbContext, IMembershipIntegrationEventService membershipIntegrationEventService)
//    //    {
//    //        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//    //        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
//    //        _membershipIntegrationEventService = membershipIntegrationEventService ?? throw new ArgumentNullException(nameof(membershipIntegrationEventService));
//    //    }
//    //    #endregion

//    //    #region Ctor


//    //    #endregion

//    //    #region Public Method(s)
//    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//    //    {
//    //        var response = default(TResponse);
//    //        var typeName = request.GetGenericTypeName();

//    //        try
//    //        {
//    //            if (_dbContext.HasActiveTransaction)
//    //            {
//    //                return await next();
//    //            }

//    //            var strategy = _dbContext.Database.CreateExecutionStrategy();

//    //            await strategy.ExecuteAsync(async () =>
//    //            {
//    //                Guid transactionId;

//    //                using (var transaction = await _dbContext.BeginTransactionAsync())
//    //                using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
//    //                {
//    //                    _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

//    //                    response = await next();

//    //                    _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

//    //                    await _dbContext.CommitTransactionAsync(transaction);

//    //                    transactionId = transaction.TransactionId;
//    //                }

//    //                //TODO: Comment out when not using RabbitMQ or EventBus
//    //                await _membershipIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);
//    //            });

//    //            return response;
//    //        }
//    //        catch (SpecialValidationException mvEx)
//    //        {
//    //            throw;
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

//    //            throw;
//    //        }
//    //    }
//    //    #endregion
//    //}


//    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//    {
//        #region Variable(s)
//        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
//        private readonly ApplicationDbContext _dbContext;
//        #endregion

//        #region Ctor

//        public TransactionBehaviour(ApplicationDbContext dbContext,
//            ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
//        {
//            _dbContext = dbContext ?? throw new ArgumentException(nameof(ApplicationDbContext));
//            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
//        }

//        #endregion

//        #region Public Method(s)

//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            var response = default(TResponse);
//            var typeName = request.GetGenericTypeName();

//            try
//            {
//                if (_dbContext.HasActiveTransaction)
//                {
//                    return await next();
//                }

//                var strategy = _dbContext.Database.CreateExecutionStrategy();

//                await strategy.ExecuteAsync(async () =>
//                {
//                    Guid transactionId;

//                    using (var transaction = await _dbContext.BeginTransactionAsync())
//                    using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
//                    {
//                        _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

//                        response = await next();

//                        _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

//                        await _dbContext.CommitTransactionAsync(transaction);

//                        transactionId = transaction.TransactionId;
//                    }
//                });

//                return response;
//            }

//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

//                throw;
//            }
//        }

//        #endregion
//    }
//}