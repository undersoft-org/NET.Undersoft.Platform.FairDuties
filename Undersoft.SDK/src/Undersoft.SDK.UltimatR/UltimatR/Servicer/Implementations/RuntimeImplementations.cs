using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Series;

namespace UltimatR
{
    public partial class AppSetup
    {
        public static void AddRuntimeImplementations(IApplicationBuilder app)
        {
            IServiceManager sm = ServiceManager.GetManager();
            IServiceRegistry service = sm.Registry;
            HashSet<Type> duplicateCheck = new HashSet<Type>();
            Type[] stores = new Type[] { typeof(IEntryStore), typeof(IReportStore) };

            /**************************************** DataService Entity Type Routines ***************************************/
            foreach (IDeck<IEdmEntityType> contextEntityTypes in DataClientRegistry.Entities)
            {
                foreach (IEdmEntityType _entityType in contextEntityTypes)
                {
                    Type entityType = DataClientRegistry.Mappings[_entityType.Name];

                    if (duplicateCheck.Add(entityType))
                    {
                        Type callerType = DataBaseRegistry.Callers[entityType.FullName];

                        /*****************************************************************************************/
                        foreach (Type store in stores)
                        {
                            if ((entityType != null) && (DataClientRegistry.GetContext(store, entityType) != null))
                            {
                                /*****************************************************************************************/
                                service.AddScoped(
                                    typeof(IRemoteRepository<,>).MakeGenericType(store, entityType),
                                    typeof(RemoteRepository<,>).MakeGenericType(store, entityType));

                                service.AddScoped(
                                    typeof(IEntityCache<,>).MakeGenericType(store, entityType),
                                    typeof(EntityCache<,>).MakeGenericType(store, entityType));
                                /*****************************************************************************************/
                                service.AddScoped(
                                    typeof(IRemote<,>).MakeGenericType(store, entityType),
                                    typeof(RemoteSet<,>).MakeGenericType(store, entityType));
                                /*****************************************************************************************/
                                if (callerType != null)
                                {
                                    /*********************************************************************************************/
                                    service.AddScoped(
                                        typeof(IRemoteRepositoryLink<,,>).MakeGenericType(store, callerType, entityType),
                                        typeof(RemoteRepositoryLink<,,>).MakeGenericType(store, callerType, entityType));

                                    service.AddScoped(
                                        typeof(ILinkedObject<,>).MakeGenericType(store, callerType),
                                        typeof(RemoteRepositoryLink<,,>).MakeGenericType(store, callerType, entityType));
                                    /*********************************************************************************************/
                                }
                            }
                        }
                    }
                }
            }
            app.RebuildProviders();
        }
    }
}