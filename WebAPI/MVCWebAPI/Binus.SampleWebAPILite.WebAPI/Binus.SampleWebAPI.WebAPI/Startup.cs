using Microsoft.Owin;

[assembly: OwinStartup(typeof(Binus.SampleWebAPI.WebAPI.Startup))]

namespace Binus.SampleWebAPI.WebAPI
{
    using global::Owin;
    using Microsoft.Web.Http.Routing;
    using System.Web.Http;
    using System;
    using Microsoft.Practices.Unity;
    using App_Start.IOC;
    using System.Linq;
    using System.Configuration;
    using Microsoft.Owin.Security.DataHandler.Encoder;
    using Microsoft.Owin.Security.OAuth;
    using Microsoft.Owin;
    using App_Start.JWT;
    using System.Web.Http.Dispatcher;
    using Data.Infrastructures.Training.MSSQL;
    using Data.DBContext.Training.MSSQL;
    using App_Start.Routing;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;
    using App_Start.JWT.RecDB;
    using Data.Repositories.Training.RecDB.MSSQL.Sample;
    using Services.Training.RecDB.MSSQL.Sample;

    public partial class Startup
    {
        public void Configuration(IAppBuilder Builder)
        {
            
            ConfigureOAuth(Builder);
       
            var Configuration = new HttpConfiguration();
            var HTTPServer = new HttpServer(Configuration);
            #region Custom Routing and WebAPI versionong
            Builder.UseWebApi(Configuration);

            // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            Configuration.AddApiVersioning(O => O.ReportApiVersions = true);



            Configuration.Routes.MapHttpRoute(
                "VersionedUrl",
                "api/{namespace}/{application}/v{apiVersion}/{module}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { apiVersion = new ApiVersionRouteConstraint() });
            Configuration.Routes.MapHttpRoute(
               "DefaultApi",
                "api/{namespace}/{application}/v{apiVersion}/{module}/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional },
               constraints: new { apiVersion = new ApiVersionRouteConstraint() });
            Configuration.Routes.MapHttpRoute(
               "VersionedNoAppUrl",
               "api/{namespace}/v{apiVersion}/{module}/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional },
               constraints: new { apiVersion = new ApiVersionRouteConstraint() });
            Configuration.Routes.MapHttpRoute(
               "DefaultApiNoApp",
                "api/{namespace}/v{apiVersion}/{module}/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional },
               constraints: new { apiVersion = new ApiVersionRouteConstraint() });
            Configuration.Routes.MapHttpRoute(
                "VersionedQueryString",
                "api/{namespace}/{application}/{module}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            Configuration.Routes.MapHttpRoute(
               "VersionedQueryStringWithAction",
              "api/{namespace}/{application}/{module}/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional });

           
            
            Configuration.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(Configuration));
            #endregion

            #region Register DBContext, Service, Repository To Unity
            var Container = new UnityContainer();

            Container.RegisterType<RecDBMSSQLIDBFactory, RecDBMSSQLDBFactory>(new HierarchicalLifetimeManager());
            //Container.RegisterType<BookDBMongoDBIDBFactory, BookDBMongoDBDBFactory>(new HierarchicalLifetimeManager());
           
           
            //Container.RegisterType<BookDBOracleIDBFactory, BookDBOracleDBFactory>(new HierarchicalLifetimeManager());
            
            Container.RegisterTypes(
            AllClasses.FromAssemblies(typeof(RecDBRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository")),
            WithMappings.FromAllInterfaces);
            // Container.RegisterType<IRolesRepository, RolesRepository>(new InjectionConstructor("DeveloperCompetencyDBEntities"));

            Container.RegisterTypes(
           AllClasses.FromAssemblies(typeof(RecDBService).Assembly)
               .Where(t => t.Name.EndsWith("Service")),
           WithMappings.FromAllInterfaces);

            Configuration.DependencyResolver = new UnityResolver(Container);
            #endregion

            //MongoDB Datetime Converter
            BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.UtcInstance);

            //Allow Cross Domain Access
            Builder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            Builder.UseWebApi(HTTPServer);
        }


        #region OAuth 2 to handle request JWT Token 
        private void ConfigureOAuth(IAppBuilder APP)
        {
            var Issuer = ConfigurationManager.AppSettings["issuer"];
            var Secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);
           
            //Login To database BookDB
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/RecDB/token"),
                RefreshTokenProvider = new RefreshTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToInt16(ConfigurationManager.AppSettings["TokenTime"])),
                Provider = new RecDBCustomOAuthProvider()
            };

            APP.CreatePerOwinContext(() => new RecDBMSSQLDBContext());        
            APP.UseOAuthAuthorizationServer(OAuthServerOptions);
            APP.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        
        }
        #endregion
    }
}
