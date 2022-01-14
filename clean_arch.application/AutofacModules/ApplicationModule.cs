using Autofac;
using System.Reflection;

namespace clean_arch.application.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {
        #region Properties
        public string QueriesConnectionString { get; }
        #endregion

        #region Ctor

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }
        #endregion

        #region Protect Method(s)

        protected override void Load(ContainerBuilder builder)
        {

            #region Entity Repositories

            //   builder.RegisterType<CustomerRepo>()
            //.As<ICodeTypeRepository>()
            //.InstancePerLifetimeScope();


            //   builder.RegisterType<CustomerRepository>()
            //       .As<ICustomerRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MemberTypeRepository>()
            //       .As<IMemberTypeRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipRepository>()
            //       .As<IMembershipRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipChargeRateRepository>()
            //       .As<IMembershipChargeRateRepository>();

            //   builder.RegisterType<MembershipSuspensionReleaseRequestRepository>()
            //       .As<IMembershipSuspensionReleaseRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipSuspensionRequestRepository>()
            //       .As<IMembershipSuspensionRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<UserAccountRepository>()
            //       .As<IUserAccountRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MemberStatusReasonCodeRepository>()
            //       .As<IMemberStatusReasonCodeRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipRenewalAdviceSettingRepository>()
            //       .As<IMembershipRenewalAdviceSettingRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipResignationRequestRepository>()
            //       .As<IMembershipResignationRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipDefermentRequestRepository>()
            //       .As<IMembershipDefermentRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipDefermentReleaseRequestRepository>()
            //       .As<IMembershipDefermentReleaseRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<BatchMembershipDefermentRequestRepository>()
            //       .As<IBatchMembershipDefermentRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<BatchMembershipWaiverRequestRepository>()
            //       .As<IBatchMembershipWaiverRequestRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<MembershipModuleSettingRepository>()
            //       .As<IMembershipModuleSettingRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<OperationReasonRepository>()
            //       .As<IOperationReasonRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<SourceChannelRepository>()
            //       .As<ISourceChannelRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<SourceChannelPamentMethodRepository>()
            //       .As<ISourceChannelPaymentMethodRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<SourceChannelUserRepository>()
            //       .As<ISourceChannelUserRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<FileRepository>()
            //       .As<IFileRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<CustomerCategoryTypeRepository>()
            //       .As<ICustomerCategoryTypeRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<CustomerCategoryRepository>()
            //       .As<ICustomerCategoryRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<WarehouseRepository>()
            //       .As<IWarehouseRepository>()
            //       .InstancePerLifetimeScope();

            //   builder.RegisterType<PaymentModeRepository>()
            //       .As<IPaymentModeRepository>()
            //       .InstancePerLifetimeScope();

            //builder.RegisterType<MembershipTransactionRepository>()
            //   .As<IMembershipTransactionRepository>()
            //   .InstancePerLifetimeScope();
            #endregion

            //#region CRUD Services

            //builder.RegisterType<CodeTypeService>()
            //.As<ICodeTypeService>()
            //.InstancePerLifetimeScope();

            //builder.RegisterType<MembershipBatchJobService>()
            //.As<IMembershipBatchJobService>()
            //.InstancePerLifetimeScope();

            //builder.RegisterType<FileService>()
            //.As<IFileService>()
            //.InstancePerLifetimeScope();

            //builder.RegisterType<MemberTypeService>()
            // .As<IMemberTypeService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<MemberStatusReasonCodeService>()
            // .As<IMemberStatusReasonCodeService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<CustomerCheckInService>()
            // .As<ICustomerCheckInService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<MembershipRenewalAdviceSettingService>()
            // .As<IMembershipRenewalAdviceSettingService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<MembershipModuleSettingService>()
            // .As<IMembershipModuleSettingService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<OperationReasonService>()
            // .As<IOperationReasonService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<SourceChannelService>()
            // .As<ISourceChannelService>()
            // .InstancePerLifetimeScope();

            ////builder.RegisterType<MembershipTransactionService>()
            ////.As<IMembershipTransactionService>()
            ////.InstancePerLifetimeScope();

            //builder.RegisterType<CustomerCategoryTypeService>()
            // .As<ICustomerCategoryTypeService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<CustomerCategoryService>()
            // .As<ICustomerCategoryService>()
            // .InstancePerLifetimeScope();

            //builder.RegisterType<WarehouseService>()
            // .As<IWarehouseService>()
            // .InstancePerLifetimeScope();
            //#endregion

            //#region CQRS
            //builder.Register(c => new AddressQueries(QueriesConnectionString))
            //    .As<IAddressQueries>()
            //    .InstancePerLifetimeScope();
            //#endregion

            //#region IntegrationEventhandler
            //builder.RegisterAssemblyTypes(typeof(ShoppingCartPaidIntegrationEventHandler).GetTypeInfo().Assembly)
            //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
            //#endregion
        }
        #endregion

    }
}